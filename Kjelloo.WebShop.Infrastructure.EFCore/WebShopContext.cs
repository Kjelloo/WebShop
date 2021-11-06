using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebShop.Infrastructure.Data.Entities;

namespace WebShop.Infrastructure.Data
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions<WebShopContext> options) : base(options) {}
        
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (var i = 1; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity
                    {
                        Id = i,
                        Name = "Product " + i
                    });
                }
                else
                {
                    modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity
                    {
                        Id = i,
                        Name = "New Product " + i
                    });
                }
                
            }   
        }
    }
}