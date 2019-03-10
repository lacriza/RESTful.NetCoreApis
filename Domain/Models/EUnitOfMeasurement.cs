using System.ComponentModel;
 
 namespace SupermarketApiRest.Domain.Models
 {
     public enum EUnitOfMeasurement : byte
     {
         //we’ll use it to simplify the responses of the products API endpoint
         [Description("Un")] Unity = 1,
         [Description("Mg")] Miligram = 2,
         [Description("Gr")] Gram = 3,
         [Description("Kg")] Kilogram = 4,
         [Description("L")] Liter = 5
     }
 }