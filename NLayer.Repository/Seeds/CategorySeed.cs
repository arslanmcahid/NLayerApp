﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>

    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //migration esnasında tabloda oluşurken ilgili default kayıtlarımızın oluşmasını istiyorsak ID leri kendimiz vermeliyiz

            builder.HasData(
                new Category { Id = 1, Name = "Kalemler" }, 
                new Category { Id = 2, Name = "Kitaplar" }, 
                new Category { Id = 3, Name = "Defterler" });



        }
    }
}
