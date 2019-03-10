using System.Collections.Generic;
using System.Threading.Tasks;
using SupermarketApiRest.Domain.Models;
using SupermarketApiRest.Domain.Services.Communication;

namespace SupermarketApiRest.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
    }
}