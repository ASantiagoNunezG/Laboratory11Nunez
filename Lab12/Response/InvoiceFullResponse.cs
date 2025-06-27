namespace Lab12.Response
{
    public class InvoiceFullResponse
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        // Cliente
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;

        // Detalles
        public List<DetailItemResponse> Details { get; set; } = new();
    }
}
