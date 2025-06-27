using Lab12.Data;
using Lab12.Models;
using Lab12.Request;
using Lab12.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lab12.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceCustomController : ControllerBase
    {
        private readonly Context _context;

        public InvoiceCustomController(Context context)
        {
            _context = context;
        }

        // 5-> Insertar Invoice
        [HttpPost]
        public InvoiceResponse InsertInvoice(InvoiceRequest request)
        {
            var invoice = new Invoice
            {
                Date = request.Date,
                InvoiceNumber = request.InvoiceNumber,
                Total = request.Total,
                CustomerId = request.CustomerId
            };

            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            var customer = _context.Customers.Find(invoice.CustomerId);

            return new InvoiceResponse
            {
                Date = invoice.Date,
                InvoiceNumber = invoice.InvoiceNumber,
                Total = invoice.Total,
                CustomerId = invoice.CustomerId,
                Customer = customer!
            };
        }


        //lista de facturas y busqueda por nombres | Datos Factura y cliente ordenado descendentemente por nombre
        [HttpGet("search-full-by-customer")]
        public List<InvoiceFullResponse> SearchFullByCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<InvoiceFullResponse>();

            var invoices = _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Details)
                    .ThenInclude(d => d.Product)
                .Where(i => i.Customer.Active &&
                            (i.Customer.FirstName.Contains(name) || i.Customer.LastName.Contains(name)))
                .OrderByDescending(i => i.Customer.LastName)
                .ToList();

            var result = invoices.Select(i => new InvoiceFullResponse
            {
                InvoiceId = i.InvoiceId,
                InvoiceNumber = i.InvoiceNumber,
                Date = i.Date,
                Total = i.Total,
                CustomerFirstName = i.Customer.FirstName,
                CustomerLastName = i.Customer.LastName,
                CustomerEmail = i.Customer.Email,
                Details = i.Details.Select(d => new DetailItemResponse
                {
                    ProductName = d.Product.Name,
                    ProductPrice = d.Product.Price,
                    Amount = d.Amount,
                    Price = d.Price,
                    SubTotal = d.SubTotal
                }).ToList()
            }).ToList();

            return result;
        }


        //Numero 10, endpoint lista de detalles de factura
        [HttpGet("{invoiceNumber}")]
        public List<DetailWithInvoiceCustomerResponse> GetDetailsByInvoiceNumber(string invoiceNumber)
        {
            if (string.IsNullOrWhiteSpace(invoiceNumber))
                return new();

            var result = _context.Details
                .Include(d => d.Invoice)
                    .ThenInclude(i => i.Customer)
                .Include(d => d.Product)
                .Where(d => d.Invoice.InvoiceNumber.Contains(invoiceNumber))
                .OrderBy(d => d.Invoice.Customer.LastName)
                .ThenBy(d => d.Invoice.InvoiceNumber)
                .Select(d => new DetailWithInvoiceCustomerResponse
                {
                    CustomerFullName = d.Invoice.Customer.FirstName + " " + d.Invoice.Customer.LastName,
                    CustomerEmail = d.Invoice.Customer.Email,
                    InvoiceNumber = d.Invoice.InvoiceNumber,
                    InvoiceDate = d.Invoice.Date,
                    InvoiceTotal = d.Invoice.Total,

                    DetailId = d.DetailId,
                    Amount = d.Amount,
                    Price = d.Price,
                    SubTotal = d.SubTotal,

                    ProductName = d.Product.Name
                })
                .ToList();

            return result;
        }

        // punto 11 endpoint que devueelve factura y detalles por fecha (rango)
        [HttpGet]
        public List<DetailByDateResponse> GetDetailsByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = _context.Details
                .Include(d => d.Invoice)
                .Include(d => d.Product)
                .Where(d => d.Invoice.Date >= startDate && d.Invoice.Date <= endDate)
                .OrderBy(d => d.Invoice.Date)
                .ThenBy(d => d.Product.Name)
                .Select(d => new DetailByDateResponse
                {
                    InvoiceNumber = d.Invoice.InvoiceNumber,
                    InvoiceDate = d.Invoice.Date,
                    InvoiceTotal = d.Invoice.Total,

                    ProductName = d.Product.Name,
                    ProductPrice = d.Product.Price,

                    Amount = d.Amount,
                    SubTotal = d.SubTotal
                })
                .ToList();

            return result;
        }


    }
}
