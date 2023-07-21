using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLayer.Core.Models;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public void ConfigureService(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("SqlConnection"));
        }
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //    var p = new Product()
        //    {
        //        ProductFeature = new ProductFeature { }              // ProductFeature product tarafından geçerli olduğu için
        //    };                                                       //aşağıda onu tanımlamak yerine burada proodcut tarafından tanımlanabilir daha doğrudur BESTPRACTICE
        //}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
       

        //silinecek kısım
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("SqlConnection");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//model oluşurken çalışacak olan method
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // tüm assembly dosyalarından git Configuration dosyalarını oku
            // bunu nasıl okuyor ==> tüm config dosyalarında IEntityTypeConfiguration<....> bu şekilde implement yaptığımız için tanıyor
            
            //eğer tek bir config okumak istersek de diyerek tek bir config dosyasını oku
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
            {
                Id=1,
                Color ="red",
                Height = 100,
                Width = 200,
                ProductId = 1
            },
            new ProductFeature
            {
                Id = 2,
                Color = "blue",
                Height = 200,
                Width = 400,
                ProductId = 2
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
