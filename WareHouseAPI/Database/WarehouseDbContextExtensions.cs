using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
            if (context.Parts.Any()) {
                return;
            }

            var parts = new List<Part>()
               {
                new Part()
                {
                    Name = "Test product",
                    Price = 1000,
                    Description = "Dummy product for the database",
                    Mass = 25.0
                }
               };

            context.AddRange(parts);
            context.SaveChanges();
        }
    }
}
