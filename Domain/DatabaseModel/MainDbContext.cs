using DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DatabaseModel
{
    public class MainDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Intermediate Tables

            //#region Books_Categories

            //modelBuilder.Entity<Book>().HasMany(r => r.Categories).WithMany(a => a.Books)
            //    .UsingEntity<Dictionary<string, object>>("Books_Categories",
            //        j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientCascade),
            //        j => j.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientCascade));

            //#endregion

  
            #endregion
        }


    }
}