using Microsoft.AspNetCore.Mvc;
using Lab12.Data;
using Lab12.Models;
using Lab12.Request;
using Lab12.Response;
using System.Collections.Generic;
using System.Linq;

namespace Lab12.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerCustomController : ControllerBase
    {
        private readonly Context _context;

        public CustomerCustomController(Context context)
        {
            _context = context;
        }

        // listado de activos
        [HttpGet]
        public List<CustomerResponse> GetAll()
        {
            return _context.Customers
                .Where(c => c.Active)
                .OrderByDescending(c => c.LastName)
                .Select(c => new CustomerResponse
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DocumentNumber = c.DocumentNumber,
                    Email = c.Email
                })
                .ToList();
        }

        // búsqueda por nombre, apellido o email (con string simple)
        [HttpGet("search")]
        public List<CustomerResponse> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<CustomerResponse>();

            return _context.Customers
                .Where(c => c.Active &&
                            (c.FirstName.Contains(query) ||
                             c.LastName.Contains(query) ||
                             c.Email.Contains(query)))
                .OrderByDescending(c => c.LastName)
                .Select(c => new CustomerResponse
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DocumentNumber = c.DocumentNumber,
                    Email = c.Email
                })
                .ToList();
        }

        // crear cliente
        [HttpPost]
        public CustomerResponse Create(CustomerRequest request)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DocumentNumber = request.DocumentNumber,
                Email = request.Email,
                Active = true
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return new CustomerResponse
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DocumentNumber = customer.DocumentNumber,
                Email = customer.Email
            };
        }

        // consultar por ID
        [HttpGet("{id}")]
        public CustomerResponse GetById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id && c.Active);
            if (customer == null) return null;

            return new CustomerResponse
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DocumentNumber = customer.DocumentNumber,
                Email = customer.Email
            };
        }

        // actualizar cliente
        [HttpPut("{id}")]
        public bool Update(int id, CustomerRequest request)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id && c.Active);
            if (customer == null) return false;

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.DocumentNumber = request.DocumentNumber;
            customer.Email = request.Email;

            _context.SaveChanges();
            return true;
        }

        // aliminación logica
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id && c.Active);
            if (customer == null) return false;

            customer.Active = false;
            _context.SaveChanges();
            return true;
        }

        // 3 en una :D
        [HttpPost]
        public List<CustomerResponse> SearchMultiple(CustomerSearchRequest request)
        {
            var query = _context.Customers.AsQueryable();

            query = query.Where(c => c.Active);

            if (!string.IsNullOrWhiteSpace(request.FirstName))
            {
                query = query.Where(c => c.FirstName.Contains(request.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(request.LastName))
            {
                query = query.Where(c => c.LastName.Contains(request.LastName));
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(c => c.Email.Contains(request.Email));
            }

            return query
                .OrderByDescending(c => c.LastName)
                .Select(c => new CustomerResponse
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DocumentNumber = c.DocumentNumber,
                    Email = c.Email
                })
                .ToList();
        }

        //actualizar numero de documento al cliente al cliente
        [HttpPut]
        public CustomerResponse UpdateDocument(CustomerResquestDN request)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == request.CustomerId && c.Active);
            if (customer == null)
            {
                throw new Exception("Cliente no encontrado.");
            }

            customer.DocumentNumber = request.DocumentNumber;

            _context.SaveChanges();

            return new CustomerResponse
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DocumentNumber = customer.DocumentNumber,
                Email = customer.Email
            };
        }

    }
}
