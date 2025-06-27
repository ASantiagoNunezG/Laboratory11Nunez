using Lab12.Data;
using Lab12.Models;
using Lab12.Request;
using Lab12.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab12.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsCustomController : ControllerBase
    {
        private readonly Context _context;
        public ProductsCustomController(Context context)
        {
            _context = context;
        }
        // listado de activos
        [HttpGet]
        public List<ProductResponse> GetAll()
        {
            return _context.Products
                .Where(c => c.Active)
                .Select(c => new ProductResponse
                {
                    Name = c.Name,
                    Price = c.Price,
                })
                .ToList();
        }

        // Inserción de productos
        [HttpPost]
        public ProductResponse InsertProduct(ProductRequest product) {
            var productRequest = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Active = true,
            };
            _context.Products.Add(productRequest);
            _context.SaveChanges();

            return new ProductResponse
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
            };
        }

        [HttpPost]
        public void InsertGroup(List<ProductRequest> request)
        {
            var model = request.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                Active = true // Por defecto, al crear un producto, está activo
            }).ToList();

            _context.Products.AddRange(model);
            _context.SaveChanges();
        }
        // aliminación logica
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var customer = _context.Products.FirstOrDefault(c => c.ProductId == id && c.Active);
            if (customer == null) return false;
            customer.Active = false;
            _context.SaveChanges();
            return true;
        }

        //Actualizar precio del producto
        [HttpPut]
        public ProductResponse UpdatePrice(ProductResquestPrice request)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == request.ProductId && p.Active);
            if (product == null)
            {
                throw new Exception("Producto no encontrado.");
            }

            product.Price = request.Price;
            _context.SaveChanges();

            return new ProductResponse
            {
                Name = product.Name,
                Price = product.Price
            };
        }


        // Eliminación lógica -- lista de productos
        [HttpPut]
        public void DeleteGroup(ProductRequestDelete request)
        {
            var ids = request.ProductsList.Select(p => p.ProductId).ToList();

            var products = _context.Products
                .Where(p => ids.Contains(p.ProductId) && p.Active)
                .ToList();

            foreach (var product in products)
            {
                product.Active = false;
            }

            _context.SaveChanges();
        }

    }
}
