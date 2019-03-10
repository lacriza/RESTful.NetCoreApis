using System;
using SupermarketApiRest.Domain.Models;

namespace SupermarketApiRest.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; }

        public CategoryResponse(bool success, string message, Category category) : base(success,
            message)
        {
            Category = category;
        }

        public CategoryResponse(Category category) : this(true, String.Empty, category)
        {
        }

        public CategoryResponse(string message) : this(false, message, null)
        {
        }
    }
}