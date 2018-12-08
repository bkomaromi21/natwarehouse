using Microsoft.AspNetCore.Mvc;
using NatWarehouse.Controllers;
using NatWarehouse.Repositories;
using WareHouseAPI.DTOs;

namespace WareHouseAPI.Controllers
{
    /// <summary>
    /// Controller for getting statistics related informations
    /// </summary>
    public class StatisticsController : WarehouseController
    {
        IStatisticsRepository statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository) {
            this.statisticsRepository = statisticsRepository;
        }

        [HttpGet("/api/statistics/get")]
        public IActionResult Get()
        {
            var heaviestStockElement = this.statisticsRepository.GetHeaviestPart();
            var mostFrequentStockElement = this.statisticsRepository.GetMostFrequentPart();

            var heaviestPart = heaviestStockElement == null ? null : heaviestStockElement.toDTO();
            var mostFrequentPart = mostFrequentStockElement == null ? null : mostFrequentStockElement.toDTO();

            var statisticsDto = new StatisticsDTO
            {
                SumMass = this.statisticsRepository.GetSumMass(),
                SumPrice = this.statisticsRepository.GetSumPrice(),
                HeaviestPart = heaviestPart,
                MostFrequentPart = mostFrequentPart
            };

            return Ok(statisticsDto);
        }
    }
}
