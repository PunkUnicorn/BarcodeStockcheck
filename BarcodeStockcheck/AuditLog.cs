namespace BarcodeStocktake
{
    public class AuditLog
    {
        public string Code { get; set; } = "";
        public string Location { get; set; } = "";
        public string Title { get; set; } = "";
        public int Increment { get; set; }
        public DateTime AuditLogTimestamp { get; set; }
    }
}