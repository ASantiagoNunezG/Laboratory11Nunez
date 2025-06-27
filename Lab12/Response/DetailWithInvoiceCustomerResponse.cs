namespace Lab12.Response
{
    public class DetailWithInvoiceCustomerResponse
    {
        public string CustomerFullName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceTotal { get; set; }

        public int DetailId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }

        public string ProductName { get; set; } = string.Empty;
    }
}

