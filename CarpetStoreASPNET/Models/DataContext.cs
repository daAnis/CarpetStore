using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarpetStoreASPNET.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SizeAndPrice> SizesAndPrices { get; set; }

        public DataContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=carpet;Username=admin;Password=admin");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasData(
        //        new Product
        //        {
        //            Id = 1,
        //            Name = "Silver",
        //            Collection = "SILVER",
        //            Country = "Турция",
        //            ProdMethod = "Машинная работа",
        //            Material = "Синтетика",
        //            PileHeight = "5 мм",
        //            Density = "620 000 узлов/м2",
        //            Shape = "Прямоугольник",
        //            Pattern = "Абстрактный",
        //            Style = "Современные ковры",
        //            AmountOfColors = 8,
        //            AmountOfInvoices = 2,
        //            PrimaryColor = "Серый",
        //            FullName = "S828A-LGRAY",
        //            Article = "59196",
        //            SizesAndPrices =
        //            {
        //                new SizeAndPrice {Id = 1, Size = "1,2 x 1,7 м", Price = 10900m},
        //                new SizeAndPrice {Id = 2, Size = "1,6 x 2,3 м", Price = 19900m},
        //                new SizeAndPrice {Id = 3, Size = "1,6 x 3,0 м", Price = 25900m},
        //                new SizeAndPrice {Id = 4, Size = "2,0 x 2,9 м", Price = 35900m},
        //                new SizeAndPrice {Id = 5, Size = "2,4 x 3,0 м", Price = 45900m},
        //                new SizeAndPrice {Id = 6, Size = "2,4 x 3,4 м", Price = 49900m},
        //                new SizeAndPrice {Id = 7, Size = "3,0 x 4,0 м", Price = 69900m}
        //            },
        //            Photos =
        //            {
        //                //"c4.jpg", "c5.jpg", "c6.jpg"
        //            }
        //        }
        //    );
        //}
    }
}