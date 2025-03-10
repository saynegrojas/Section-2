using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Entities;

namespace ProductsAPI.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }



        // Uncomment for sample data
        // Seed Db with sample data
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Product>().HasData(
        //         new Product { Id = 1, Name = "Product A", Price = 10.99m },
        //         new Product { Id = 2, Name = "Product B", Price = 20.99m },
        //         new Product { Id = 3, Name = "Product C", Price = 30.99m }
        //     );
        // }
    }


}