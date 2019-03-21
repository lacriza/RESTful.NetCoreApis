using System.Collections.Generic;
using System.Threading.Tasks;
using SupermarketApiRest.Domain.Models;
using SupermarketApiRest.Domain.Services.Communication;

namespace SupermarketApiRest.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}