using System.Collections.Generic;
using System.Threading.Tasks;
using SupermarketApiRest.Domain.Models;

namespace SupermarketApiRest.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}