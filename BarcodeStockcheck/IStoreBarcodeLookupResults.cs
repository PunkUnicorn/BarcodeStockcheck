//using System.Dynamic;
//using static System.Windows.Forms.Design.AxImporter;
//using System.Threading;
//using RestSharp;
//using RestSharp.Authenticators;

namespace BarcodeStocktake
{
    public interface IStoreBarcodeLookupResults
    {
        void Add(string code, BarcodeLookupResult result);
        BarcodeLookupResult? GetByCode(string code);
    }

}