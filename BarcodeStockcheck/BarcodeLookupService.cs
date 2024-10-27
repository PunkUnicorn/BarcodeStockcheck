using Newtonsoft.Json;

namespace BarcodeStocktake
{

    public class BarcodeLookupService
    {
        private IExecuteBarcodeLookup _executeLookup;
        public CancellationTokenSource? CancellationTokenSource { get; set; }

        public Dictionary<string, string> AliasMap {get; private set; }
        public string Error { get; private set; } = "";

        private const string AliasMapFilename = "Alpha_AliasMap.json";

        public BarcodeLookupService(IExecuteBarcodeLookup executeLookup)
        {
            _executeLookup = executeLookup;
            if (!File.Exists(AliasMapFilename))
                File.WriteAllText(AliasMapFilename, JsonConvert.SerializeObject(new Dictionary<string, string>()));

            var amContents = File.ReadAllText(AliasMapFilename);
            AliasMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(amContents) ?? throw new InvalidOperationException(nameof(AliasMap));
        }

        public async Task<BarcodeLookupResult?> GetBarcodeInfoAsync(string scannedCode, string alias)
        {
            Error = "";

            // Initialise
            if (CancellationTokenSource == null)
            {
                CancellationTokenSource = new CancellationTokenSource();
                await _executeLookup.InitiateAsync(CancellationTokenSource.Token);
            }


            // Catch mistakes
            if (string.IsNullOrWhiteSpace(scannedCode))
            {
                Error = "Not found!";
                return null;
            }
            if (scannedCode == alias)
            {
                Error = "Not found!";
                return null;
            }


            string? barcode = null;
            // Swap weird codes for barcodes from previously aquired alias'
            if (AliasMap.ContainsKey(scannedCode))
                barcode = AliasMap[scannedCode];

            if (barcode is null && !string.IsNullOrEmpty(alias))
            {
                AddAlias(scannedCode, alias);
                barcode = scannedCode;
            }

            if (barcode == null)
                barcode = scannedCode;


            // check if saved on disk
            var existing = (BarcodeLookupResult?) null;
            if ((existing = _executeLookup.IsStored(barcode)) != null) 
                return existing;

            try
            { 
                var lookupResult = await _executeLookup.LookupAsync(barcode);
                if (lookupResult == null)
                    Error = "Not found!";

                return lookupResult;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }


            return null;
        }

        private void AddAlias(string code, string alias)
        {
            AliasMap.Add(alias, code);

            File.WriteAllText(AliasMapFilename, JsonConvert.SerializeObject(AliasMap, Formatting.Indented));
        }
    }
}