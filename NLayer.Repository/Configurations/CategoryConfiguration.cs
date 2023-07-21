using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(); // ID değişkeni birer birer artsın
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories"); // Tablonun ismini açıkça belirtmek istersek
            // Eğer isim vermezsek default olarak AppDbContext kısmındaki public DbSet<Category> Categories kısmından Categories olarak ayarlar
        }
    }
}
