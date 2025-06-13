using Lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Data
{ 
    public class Context : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=LAPTOP-R79EK4NG\SQLEXPRESS2017;Database=NunezDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
        //}
    }
}
