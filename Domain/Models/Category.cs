using System.Collections.Generic;

namespace SupermarketApiRest.Domain.Models
{
    
    //Plain old CLR object POCO class https://en.wikipedia.org/wiki/Plain_old_CLR_object
    // It means the class will have only properties to describe its basic information.
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Producs { get; set; } = new List<Product>();
    }
}