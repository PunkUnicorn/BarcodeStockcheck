using JsonFlatFileDataStore;
using Newtonsoft.Json;
//using System.Dynamic;
//using static System.Windows.Forms.Design.AxImporter;
//using System.Threading;
//using RestSharp;
//using RestSharp.Authenticators;

namespace BarcodeStocktake
{
    public class StoreLookupResults : IStoreBarcodeLookupResults
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

}