using Lab12.Data;
using Lab12.Models;
using Lab12.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab12.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly Context _context;

        public InvoiceDetailController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public List<Detail> InsertDetailsToInvoice(FacturaDetailRequest request)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == request.InvoiceId);
            if (invoice == null)
            {
                return new List<Detail>(); 
            }

            var details = request.ListaDetails.Select(d => new Detail
            {
                InvoiceId = request.InvoiceId,
                ProductId = d.ProductId,
                Amount = d.Amount,
                Price = d.Price,
                SubTotal = d.SubTotal
            }).ToList();

            _context.Details.AddRange(details);
            _context.SaveChanges();

            return details;
        }
    }
}
