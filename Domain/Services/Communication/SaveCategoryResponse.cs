using System;
using SupermarketApiRest.Domain.Models;

namespace SupermarketApiRest.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; }

        public SaveCategoryResponse(bool success, string message, Category category) : base(success,
            message)
        {
            Category = category;
        }

        public SaveCategoryResponse(Category category) : this(true, String.Empty, category)
        {
        }

        public SaveCategoryResponse(string message) : this(false, message, null)
        {
        }
    }
}