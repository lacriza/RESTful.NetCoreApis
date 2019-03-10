using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SupermarketApiRest.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMesages(this ModelStateDictionary state)
        {
            return state.SelectMany(s => s.Value.Errors).Select(s => s.ErrorMessage).ToList();
        }
    }
}