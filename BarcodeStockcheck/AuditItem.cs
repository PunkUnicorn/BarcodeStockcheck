namespace BarcodeStocktake
{
    public class AuditItem : IHasBarcodeScanResult
    {
        public AuditItem(IStoreLookupResults storeLookupResults, string code, string storageLocation)
        {
            Code = code;
            StorageLocation = storageLocation;
            if (storeLookupResults != null)
            { 
                var clone = storeLookupResults.GetByCode(code)
                    ?? throw new NullReferenceException(nameof(storeLookupResults.GetByCode));
                //StorageLocation = storageLocation;

                Title = clone.Title;
                SourceUrl = clone.SourceUrl;
                Publisher = clone.Publisher;
                Description = clone.Description;
                ImageUrl = clone.ImageUrl;  
                ImageThumbnailBase64 = clone.ImageThumbnailBase64;
                JsonResponseFilename = clone.JsonResponseFilename;
                LookupTimestamp = clone.LookupTimestamp;
            }
        }

        public int id { get;set; }
        public string Code { get; set; } = "";
        public int Quantity { get; set; }
        public string StorageLocation { get; set; }

        public string? Title { get; set; }
        public string? SourceUrl { get; set; }
        public string? Publisher { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailBase64 { get; set; }
        public string? JsonResponseFilename { get; set; }
        public DateTime? LookupTimestamp { get; set; }
        public DateTime? InsertTimestamp { get; set; }
        public DateTime? LastUpdateTimestamp { get; set; }
    }
}