using SupermarketApiRest.Domain.Persistence.Contexts;

namespace SupermarketApiRest.Domain.Persistence
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}