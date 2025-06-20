namespace Lab12.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Total { get; set; }

        // Clave foránea
        public int CustomerId { get; set; }

        // Propiedad de navegación
        public Customer Customer { get; set; }
    }
}
