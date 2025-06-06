namespace Laboratory11Nunez.Models
{
    public class Detail
    {

        public int DetailId { get; set; }

        public int Amount { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }
        public bool Active { get; set; }

        //llaves foráneas
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
    }
}
