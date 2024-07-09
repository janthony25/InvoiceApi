using InvoiceApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<tblCustomer> tblCustomer { get; set; }
        public DbSet<tblInvoice> tblInvoice { get; set; }
        public DbSet<tblInvoiceItem> tblInvoiceItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCustomer>()
                .HasMany(c => c.tblInvoice)
                .WithOne(i => i.tblCustomer)
                .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<tblInvoice>()
                .HasMany(i => i.tblInvoiceItem)
                .WithOne(ii => ii.tblInvoice)
                .HasForeignKey(ii => ii.InvoiceId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
