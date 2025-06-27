using Lab12.Models;

namespace Lab12.Request
{
    public class InvoiceRequest
    {
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal Total { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
