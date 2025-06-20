using Lab12.Data;
using Lab12.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceCustomController : ControllerBase
    {
        private readonly Context _context;

        public InvoiceCustomController(Context context)
        {
            _context = context;
        }

        // GET: api/InvoiceCustom/search-by-customer?name=juan
        [HttpGet("search-by-customer")]
        public List<InvoiceWithCustomerResponse> SearchByCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<InvoiceWithCustomerResponse>();

            var query = _context.Invoices
                .Include(i => i.Customer)
                .Where(i => i.Customer.Active &&
                            (i.Customer.FirstName.Contains(name) || i.Customer.LastName.Contains(name)))
                .OrderByDescending(i => i.Customer.LastName)
                .Select(i => new InvoiceWithCustomerResponse
                {
                    InvoiceId = i.InvoiceId,
                    InvoiceNumber = i.InvoiceNumber,
                    Date = i.Date,
                    Total = i.Total,
                    CustomerFirstName = i.Customer.FirstName,
                    CustomerLastName = i.Customer.LastName,
                    CustomerEmail = i.Customer.Email
                })
                .ToList();

            return query;
        }
    }
}
