using DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DatabaseModel
{
    public class MainDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CategoryParent> CategoryParents { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Intermediate Tables

            #region Categories_Products

            modelBuilder.Entity<Category>().HasMany(r => r.Products).WithMany(a => a.Categories)
                .UsingEntity<Dictionary<string, object>>("Categories_Products",
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientCascade));

            #endregion

            #region Customers_Orders

            modelBuilder.Entity<Customer>().HasMany(r => r.Orders).WithMany(a => a.Customers)
                .UsingEntity<Dictionary<string, object>>("Customers_Orders",
                    j => j.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientCascade));

            #endregion


            #region Customers_CustomerAddress

            modelBuilder.Entity<Customer>().HasMany(r => r.Addresses).WithMany(a => a.Customers)
                .UsingEntity<Dictionary<string, object>>("Customers_CustomerAddress",
                    j => j.HasOne<CustomerAddress>().WithMany().HasForeignKey("CustomerAddressId").OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientCascade));

            #endregion


            #region Orders_Products

            modelBuilder.Entity<Order>().HasMany(r => r.Products).WithMany(a => a.Orders)
                .UsingEntity<Dictionary<string, object>>("Orders_Products",
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientCascade));

            #endregion

            #region Product_ProductImage

            modelBuilder.Entity<Product>().HasMany(r => r.ProductImages).WithMany(a => a.Products)
                .UsingEntity<Dictionary<string, object>>("Product_ProductImage",
                    j => j.HasOne<ProductImage>().WithMany().HasForeignKey("ProductImageId").OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientCascade));

            #endregion


            #endregion
        }


    }
}