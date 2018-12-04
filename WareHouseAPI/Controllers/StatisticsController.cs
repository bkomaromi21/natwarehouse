using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHouseAPI.Database;
using WareHouseAPI.DTOs;

namespace WareHouseAPI.Controllers
{
    /// <summary>
    /// Controller for getting statistics related informations
    /// </summary>
    public class StatisticsController : BaseAPIController
    {
        public StatisticsController(WarehouseDbContext context) : base(context) {}

        [HttpGet("/api/statistics/get")]
        public IActionResult Get()
        {
            var stockElements = this.context.StockElements.ToList();

            var heaviestPart = stockElements.Aggregate((currentHeaviest, x) => (currentHeaviest == null || x.Part.Mass > currentHeaviest.Part.Mass ? x : currentHeaviest));
            var mostFrequentPart = stockElements.Aggregate((currentHeaviest, x) => (currentHeaviest == null || x.Quantity > currentHeaviest.Quantity ? x : currentHeaviest));

            var statisticsDto = new StatisticsDTO
            {
                SumMass = stockElements.Select(el => el.Part.Mass * el.Quantity).Sum(),
                SumPrice = stockElements.Select(el => el.Part.Price * el.Quantity).Sum(),
                HeaviestPart = heaviestPart.Part.toDTO(),
                MostFrequentPart = mostFrequentPart.Part.toDTO()
            };

            return Ok(stockElements);
        }
    }
}
