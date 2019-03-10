using System.Threading.Tasks;

namespace SupermarketApiRest.Domain.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}