using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupermarketApiRest.Domain.Models;
using SupermarketApiRest.Domain.Persistence.Contexts;
using SupermarketApiRest.Domain.Repositories;

namespace SupermarketApiRest.Domain.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            /*Notice the call to Include(p => p.Category).
             We can chain this syntax to include as many entities as necessary when querying data. 
             EF Core is going to translate it to a join when performing the select.
             */
            return await _context.Products.Include(p => p.Category).ToListAsync();
            /*EF Core, by default,
             does not include related entities to your models when you querying data because
             it could be very slow 
             (imagine a model with ten related entities, all all related entities having its own relationships).*/
        }

        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

        public async Task<Product> FindByIdAsync(int id) => await _context.Products.FindAsync(id);

        public void Update(Product product) => _context.Products.Update(product);

        public void Remove(Product product) => _context.Products.Remove(product);
    }
}