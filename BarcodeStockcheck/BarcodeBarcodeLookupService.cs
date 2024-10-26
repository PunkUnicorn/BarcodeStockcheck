using RestSharp;
using Newtonsoft.Json;
using System.Dynamic;
//using System.Dynamic;
//using static System.Windows.Forms.Design.AxImporter;
//using System.Threading;
//using RestSharp;
//using RestSharp.Authenticators;

namespace BarcodeStocktake
{
    public class BarcodeBarcodeLookupService : IExecuteBarcodeLookup
    {
        private RestClient? _client;
        private CancellationToken CancellationToken;
        private string _key;
        private IStoreLookupResults _storeLookupRequests;

        public BarcodeBarcodeLookupService(IStoreLookupResults storeLookupRequests)
        {
            _storeLookupRequests = storeLookupRequests;
        }

        public async Task InitiateAsync(CancellationToken ctxToken)
        {
            CancellationToken = ctxToken;
            _key = File.ReadAllText("Alpha_barcodelookup.key");
            var options = new RestClientOptions("https://api.barcodelookup.com/v3/products");
            _client = new RestClient(options);
        }

        public BarcodeLookupResult? IsStored(string code)
        {
            return _storeLookupRequests.GetByCode(code);
        }

        public async Task<BarcodeLookupResult?> LookupAsync(string code)
        {
            var request = new RestRequest();
            request.AddQueryParameter("barcode", code);
            request.AddQueryParameter("formatted", "y");
            request.AddQueryParameter("key", _key);

            try
            {
                var response = await _client.GetAsync(request, CancellationToken);

                if (!response.IsSuccessful)
                    return null;

                return MakeBarcodeLookupResult(code, response);
            }
            catch (HttpRequestException ex) when (ex.Message == "Request failed with status code BadRequest")
            {
                return null;
            }
        }

        private BarcodeLookupResult MakeBarcodeLookupResult(string code, RestResponse response)
        {
            if (response.Content is null)
                throw new NullReferenceException(nameof(response.Content));

            var jsonFilename = ResponseUtil.MakeJsonFile(code, response);

            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(response.Content);
            _ = ((IDictionary<string, object>)obj).Any(); // <-- sic - Force naked null reference exception

            obj = obj.products[0];

            var imageUrl = (string?)ResponseUtil.GetProp(obj, "imageUrl");
            var ret = new BarcodeLookupResult
            {
                SourceUrl = response.ResponseUri?.ToString(),
                LookupTimestamp = DateTime.Now,
                Code = code,
                CodeType = ResponseUtil.GetProp(obj, "codeType"),
                Publisher = ResponseUtil.GetProp(obj, "manufacturer"),
                Title = ResponseUtil.GetProp(obj, "title"),
                Description = ResponseUtil.GetProp(obj, "description"),
                ImageUrl = ResponseUtil.GetFirstArrayItem(obj, "images"),
                ImageThumbnailBase64 = ResponseUtil.MakeBase64Thumbnail(imageUrl),
                JsonResponseFilename = jsonFilename
            };

            var labelFromDesc = ResponseUtil.SearchDescriptionForProperties("Label", ret.Description);
            if (labelFromDesc != null)
                ret.Publisher = labelFromDesc;

            var publisherFromDesc = ResponseUtil.SearchDescriptionForProperties("Publisher", ret.Description);
            if (publisherFromDesc != null)
                ret.Publisher = publisherFromDesc;

            //if (ret.Description?.Contains("Essential Christian", StringComparison.OrdinalIgnoreCase) ?? false)
            //    ret.Publisher = "Essential Christian";

            if (ret.Publisher == "")
                ret.Publisher = null;

            _storeLookupRequests.Add(code, ret);
            return ret;
        }

    }

}