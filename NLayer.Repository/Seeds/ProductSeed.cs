﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                Name = "Kalem 1",
                CategoryId = 1,
                Price = 100,
                Stock = 20,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 2,
                Name = "Kalem 2",
                CategoryId = 1,
                Price = 120,
                Stock = 25,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 3,
                Name = "Kalem 3",
                CategoryId = 1,
                Price = 500,
                Stock = 765,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 4,
                Name = "Kitap 1",
                CategoryId = 2,
                Price = 100,
                Stock = 50,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 5,
                Name = "Kitapss 2",
                CategoryId = 2,
                Price = 420,
                Stock = 125,
                CreatedDate = DateTime.Now
            });
        }
    }
}