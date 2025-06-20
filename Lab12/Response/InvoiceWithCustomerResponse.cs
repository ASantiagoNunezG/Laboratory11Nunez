using Lab12.Models;

namespace Lab12.Response
{
    public class InvoiceWithCustomerResponse
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
