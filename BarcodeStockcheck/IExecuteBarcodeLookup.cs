//using System.Dynamic;
//using static System.Windows.Forms.Design.AxImporter;
//using System.Threading;
//using RestSharp;
//using RestSharp.Authenticators;

namespace BarcodeStocktake
{
    public interface IExecuteBarcodeLookup
    {
        Task InitiateAsync(CancellationToken ctxToken);
        BarcodeLookupResult? IsStored(string code);
        Task<BarcodeLookupResult?> LookupAsync(string code);
    }
}