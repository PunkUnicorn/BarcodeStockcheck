using System.Dynamic;

namespace BarcodeStocktake
{
    public class BarcodeLookupResult : IHasBarcodeScanResult
    {
        public string? SourceUrl { get;set; }
        public string Code { get; set; } = "";
        public string CodeType { get; set; } = "";
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailBase64 { get; set; }
        //public ExpandoObject AdditionalDetails { get; set; } = new ExpandoObject();
        public string? JsonResponseFilename { get; set; }

        public DateTime? LookupTimestamp { get; set; }
        //public string? StorageLocation { get; set; }
    }
}