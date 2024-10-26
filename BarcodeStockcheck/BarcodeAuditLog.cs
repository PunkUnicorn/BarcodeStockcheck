namespace BarcodeStocktake
{
    public class BarcodeAuditLog
    {
        public string Code { get; set; } = "";
        public string CodeType { get; set; } = "";
        public string Title { get; set; } = "";

        public int Increment { get; set; }
        public string Location { get; set; } = "";

        public DateTime AuditLogTimestamp { get; set; }

    }
}