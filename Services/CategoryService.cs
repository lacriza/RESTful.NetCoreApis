using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using SupermarketApiRest.Domain.Models;
 using SupermarketApiRest.Domain.Persistence.Repositories;
 using SupermarketApiRest.Domain.Repositories;
 using SupermarketApiRest.Domain.Services;
 using SupermarketApiRest.Domain.Services.Communication;

namespace SupermarketApiRest.Services
 {
     public class CategoryService : ICategoryService
     {
         private readonly ICategoryRepository _categoryRepository;
         private readonly IUnitOfWork _unitOfWork;
 
         public CategoryService(
             ICategoryRepository categoryRepository,
             IUnitOfWork unitOfWork)
         {
             _categoryRepository = categoryRepository;
             _unitOfWork = unitOfWork;
         }
 
         public async Task<IEnumerable<Category>> ListAsync()
         {
             return await _categoryRepository.ListAsync();
         }
 
         public async Task<SaveCategoryResponse> SaveAsync(Category category)
         {
             try
             {
                 await _categoryRepository.AddAsync(category);
                 await _unitOfWork.CompleteAsync();
                 return new SaveCategoryResponse(category);
             }
             catch (Exception e)
             {
                 
                 //TODO: Do some logging stuff
                 return new SaveCategoryResponse($"Save of category is failed {e}");
             }
         }
     }
 }