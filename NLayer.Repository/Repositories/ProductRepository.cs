using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Product>> GetProductsWithCategory()
        {
            //Eager Loading ==> Daha data çekilirken kategorisinin de alınmasını istedik
            // Eger ihtiyac olduğu sırada category bilgisini çekseydik bu da LAZY LOADIN olurdu
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
