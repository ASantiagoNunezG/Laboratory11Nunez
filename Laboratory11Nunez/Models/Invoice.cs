namespace Laboratory11Nunez.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public float Total { get; set; }
        public bool Active { get; set; }

        //llaves foráneas
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
