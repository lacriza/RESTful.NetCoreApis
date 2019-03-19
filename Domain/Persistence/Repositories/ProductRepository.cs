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
            return await _context.Products.ToListAsync();
        }

        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

        public async Task<Product> FindByIdAsync(int id) => await _context.Products.FindAsync(id);

        public void Update(Product product) => _context.Products.Update(product);

        public void Remove(Product product) => _context.Products.Remove(product);
    }
}