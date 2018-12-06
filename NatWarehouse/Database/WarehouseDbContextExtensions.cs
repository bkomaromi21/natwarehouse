using System.Collections.Generic;
using System.Linq;
using WareHouseAPI.Entities;

namespace WareHouseAPI.Database
{
    /// <summary>
    /// Extending DB context with seed functionality
    /// </summary>
    public static class WarehouseDbContextExtensions
    {
        public static void CreateSeedData(this WarehouseDbContext context)
        {
            if (context.StockElements.Any()) {
                return;
            }

            var part = new PartEntity()
            {
                Name = "Test product",
                Price = 1000,
                Description = "Dummy product for the database",
                Mass = 25.0
            };

            var stockElement = new StockElementEntity
            {
                Part = part,
                Quantity = 1
            };

            context.Add(stockElement);
            context.SaveChanges();
        }
    }
}
