using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using SupermarketApiRest.Domain.Models;
 using SupermarketApiRest.Domain.Persistence.Contexts;
 using SupermarketApiRest.Domain.Repositories;
 
 namespace SupermarketApiRest.Domain.Persistence.Repositories
 {
     public class CategoryRepository : BaseRepository, ICategoryRepository
 
     {
         // a repository shouldn’t persist data, it’s just an in-memory collection of objects.
         public CategoryRepository(AppDbContext context) : base(context)
         {
         }
 
         public async Task<IEnumerable<Category>> ListAsync()
         {
             return await _context.Categories.ToListAsync();
         }
 
         public async Task AddAsync(Category category)
         {
             await _context.Categories.AddAsync(category);
         }

         public async Task<Category> FindByIdAsync(int id) => await _context.Categories.FindAsync(id);

         public  void Update(Category category)
         {
             _context.Categories.Update(category);
         }

         public void Remove(Category category)
         {
              _context.Categories.Remove(category);
         }

     }
 }