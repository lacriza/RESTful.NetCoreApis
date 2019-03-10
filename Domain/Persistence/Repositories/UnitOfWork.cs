using System.Threading.Tasks;
using SupermarketApiRest.Domain.Persistence.Contexts;

namespace SupermarketApiRest.Domain.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        
        
        //todo: research - implementing rollback operation
    }
}