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

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception e)
            {
                //TODO: Do some logging stuff
                return new CategoryResponse($"Save of category is failed {e}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);
            if (existingCategory == null) return new CategoryResponse("Category not found");
            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse(
                    $"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);
            if (existingCategory == null) return new CategoryResponse("Category not found");
            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse(
                    $"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}