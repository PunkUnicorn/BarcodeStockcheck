
using RestSharp.Authenticators;
using RestSharp;
using JsonFlatFileDataStore;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text.RegularExpressions;
//using System.Dynamic;
//using static System.Windows.Forms.Design.AxImporter;
//using System.Threading;
//using RestSharp;
//using RestSharp.Authenticators;

namespace BarcodeStocktake
{

    public interface IStoreLookupResults
    {
        void Add(string code, BarcodeLookupResult result);
        BarcodeLookupResult? GetByCode(string code);
    }

    public class StoreLookupResults : IStoreLookupResults
    {
        private DataStore _store = new DataStore("Alpha_StoreLookupResults.json");

        public void Add(string code, BarcodeLookupResult result)
        {
            var collection = _store.GetCollection("lookup");

            collection.InsertOne(result);
        }

        public BarcodeLookupResult? GetByCode(string code)
        {
            var collection = _store.GetCollection("lookup");
            var results = collection.AsQueryable().Where(e => e.code == code).ToList();
            if (results.Any())
                return JsonConvert.DeserializeObject<BarcodeLookupResult>(JsonConvert.SerializeObject(results.First()));

            return null;
        }
    }


    public static class ResponseUtil
    { 
        public static string? MakeBase64Thumbnail(string? imageUrl)
        {
            if (imageUrl is null)
                return null;

            // ...

            return null;
        }

        public static string? GetProp(dynamic obj, string key)
        {
            if (obj is not IDictionary<string, object>)
                return null;

            var dict = (IDictionary<string, object>)obj;
            if (dict.ContainsKey(key))
                return dict[key].ToString();

            foreach (var nestedParent in dict.Values.Where(value => value is object && value is not string).ToList())
            {
                var nest = GetProp(nestedParent, key);
                if (nest is not null)
                    return nest;
            }

            return null;
        }

        public static string? GetFirstArrayItem(dynamic obj, string key)
        {
            if (obj is not IDictionary<string, object>)
                return null;

            var dict = (IDictionary<string, object>) obj;
            if (dict.TryGetValue(key, out var val))
            { 
                var array = (IEnumerable<object>)val;
                if (array.Any())
                    return array.First().ToString();
            }
            return null;
        }


        public static string MakeJsonFile(string code, RestResponse response)
        {
            if (!Directory.Exists("json"))
                Directory.CreateDirectory("json");

            var jsonFilename = $@"json\{code}.json";
            File.WriteAllText(jsonFilename, response.Content);
            return jsonFilename;
        }

        public static string? SearchDescriptionForProperties(string key, string description)
        {
            var regex = new Regex($@"{key}\s?\s?\s?:\s?\s?\s?([a-z A-Z]*)[,|.]");

            return regex.IsMatch(description)
                ? regex.Match(description).Groups[1].Value
                : null;
        }
    }

    public class BarcodeGoUpcService : IExecuteBarcodeLookup
    {
        private RestClient _client;
        private CancellationToken CancellationToken;
        private IStoreLookupResults _storeLookupRequests;

        public BarcodeGoUpcService(IStoreLookupResults storeLookupRequests)
        {
            _storeLookupRequests = storeLookupRequests;
        }

        public async Task InitiateAsync(CancellationToken ctxToken)
        { 
            CancellationToken = ctxToken;
            var bearerToken = File.ReadAllText("Alpha_go-upc.key");
            var options = new RestClientOptions("https://go-upc.com/api/v1") { Authenticator = new JwtAuthenticator(bearerToken) };
            _client = new RestClient(options);
        }

        public BarcodeLookupResult? IsStored(string code)
        {
            return _storeLookupRequests.GetByCode(code);
        }

        public async Task<BarcodeLookupResult?> LookupAsync(string code)
        {
            var request = new RestRequest($"code/{code}");

            try
            { 
                var response = await _client.GetAsync(request, CancellationToken);
                return MakeBarcodeLookupResult(code, response);
            }
            catch (HttpRequestException ex ) when (ex.Message == "Request failed with status code BadRequest") 
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

            var imageUrl = (string?)ResponseUtil.GetProp(obj, "imageUrl");
            var ret = new BarcodeLookupResult
            {
                SourceUrl = response.ResponseUri?.ToString(),
                LookupTimestamp = DateTime.Now,
                Code = code,
                CodeType = ResponseUtil.GetProp(obj, "codeType"),
                Publisher = ResponseUtil.GetProp(obj, "publisher"),
                Title = ResponseUtil.GetProp(obj, "name"),
                Description = ResponseUtil.GetProp(obj, "description"),
                ImageUrl = imageUrl,
                ImageThumbnailBase64 = ResponseUtil.MakeBase64Thumbnail(imageUrl),
                JsonResponseFilename = jsonFilename
            };

            var labelFromDesc = ResponseUtil.SearchDescriptionForProperties("Label", ret.Description);
            if (labelFromDesc != null)
                ret.Publisher = labelFromDesc;

            var publisherFromDesc = ResponseUtil.SearchDescriptionForProperties("Publisher", ret.Description);
            if (publisherFromDesc != null)
                ret.Publisher = publisherFromDesc;

            if (ret.Publisher == "")
                ret.Publisher = null;

            _storeLookupRequests.Add(code, ret);
            return ret;
        }

    }

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