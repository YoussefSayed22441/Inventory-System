
using Inventory_System.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System.Infrastructure.Data
{
    public class InventoryDbContext :DbContext
    {
        public InventoryDbContext (DbContextOptions<InventoryDbContext> options)     : base(options)
        {

        }

        // DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notification>  Notifications { get; set; }
        public DbSet<Supplier> Suppliers  { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers  { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }


        // Configure the model and apply configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductSupplier>()
                .HasKey(ps => new { ps.ProductId, ps.SupplierId });
        }

    }

}
