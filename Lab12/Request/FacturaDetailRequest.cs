
using Lab12.Models;

namespace Lab12.Request
{
    public class FacturaDetailRequest
    {
        public int InvoiceId { get; set; } // creo que este ta mal
        public List<DetailRequest> ListaDetails { get; set; }
    }
}
