﻿namespace Lab12.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal Total { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Details
        public List<Detail> Details { get; set; } = new();
    }
}
