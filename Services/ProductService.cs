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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(
            IUnitOfWork unitOfWork, 
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Product>> ListAsync() => await _productRepository.ListAsync();

        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception e)
            {
                return new ProductResponse($"Failed to create product: {e}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);
            if (existingProduct == null) return new ProductResponse("Product not found");
            var existingCategory = await _categoryRepository.FindByIdAsync(product.CategoryId);
            if(existingCategory == null) return new ProductResponse("Invalid category");
           
            existingProduct.Name = product.Name;
            existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            existingProduct.QuantityInPackage = product.QuantityInPackage;
            existingProduct.CategoryId = product.CategoryId;
            try
            {
                _productRepository.Update(product);
                await _unitOfWork.CompleteAsync();
                
                return new ProductResponse(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"Update of product is failed: {e}");
            }
        }


        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);
            if (existingProduct == null) return new ProductResponse("Product not found");
            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"Delete of product is failed: {e}");
            }
        }
    }
}