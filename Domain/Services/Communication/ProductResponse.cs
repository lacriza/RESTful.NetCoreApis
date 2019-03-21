using System;
using SupermarketApiRest.Domain.Models;

namespace SupermarketApiRest.Domain.Services.Communication
{
    public class ProductResponse: BaseResponse
    {
        public Product Product { get; }
        public ProductResponse(bool success, string message, Product product) : base(success, message)
        {
            Product = product;
        }

        public ProductResponse(Product product): this(true, String.Empty, product)
        {
            
        }

        public ProductResponse(string message): this(false, message, null)
        {
            
        }
    }
}