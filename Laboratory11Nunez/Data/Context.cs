using Laboratory11Nunez.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboratory11Nunez.Data
{
    public class Context : DbContext
    {

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Invoice> Invoices => Set<Invoice>();

        public DbSet<Detail> Details => Set<Detail>();

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=LAB1502-05;Database=NunezDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
        //}
    }
}
