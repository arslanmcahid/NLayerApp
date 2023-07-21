using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);       //fluent API
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x=>x.Price).IsRequired().HasColumnType("decimal(18, 2)");
            builder.ToTable("Products");


            builder.HasOne(x => x.Category).WithMany(x => x.Products);
            //bir ürünün bir kategorisi olabilir lakin bir kategori birden fazla ürünün olabilir
            //normalde Id tanımlarken düzgün tanımlandığı için EfCore bunları algılayabiliyor lakin __Id gibi tanım yaparsak bunu ona tanıtmamız lazım
        }
    }
}
