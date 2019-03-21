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

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
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

        public async Task<ProductResponse> UpdateAsync(int id, Product product, int categoryId)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);
            if (existingProduct == null) return new ProductResponse("Product not found");
            existingProduct.Name = product.Name;
            existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            existingProduct.QuantityInPackage = product.QuantityInPackage;
            existingProduct.CategoryId = categoryId;
           
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