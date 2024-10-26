namespace BarcodeStocktake
{
    public interface IStoreBarcodeLookupResults
    {
        void Add(string code, BarcodeLookupResult result);
        BarcodeLookupResult? GetByCode(string code);
    }

}