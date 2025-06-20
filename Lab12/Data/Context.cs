using Lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Data
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
        //    optionsBuilder.UseSqlServer(@"Server=LAPTOP-R79EK4NG\SQLEXPRESS2017;Database=NunezDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Detail>()
                .Property(d => d.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Detail>()
                .Property(d => d.SubTotal)
                .HasPrecision(18, 2);
        }

    }
}
