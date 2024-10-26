namespace BarcodeStocktake
{
    public interface IHasBarcodeScanResult
    {
        string Code { get; }
        string? Title { get; }
        string? SourceUrl { get; }
        string? Publisher { get; }
        string? Description { get; }
        string? ImageUrl { get; }
        string? ImageThumbnailBase64 { get; }
        string? JsonResponseFilename { get; }
        DateTime? LookupTimestamp { get; }
        //string? StorageLocation { get; }
    }
}