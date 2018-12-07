using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NatWarehouse.Controllers;
using NatWarehouse.Exceptions;
using NatWarehouse.Repositories;
using WareHouseAPI.DTOs;

namespace WareHouseAPI.Controllers
{
    /// <summary>
    /// Controller class for CRUD operations on the stock elements
    /// </summary>
    public class StockElementAPIController: WarehouseController
    {
        IStockElementRepository stockElementRepository;

        public StockElementAPIController(IStockElementRepository stockElementRepository) {
            this.stockElementRepository = stockElementRepository;
        }

        [HttpGet("/api/stockelements/getall")]
        public IActionResult GetAll()
        {
            var stockElements = this.stockElementRepository.GetAll();

            var stockElementWrapper = new StockElementsDTO
            {
                StockElements = stockElements.Select(el => el.toDTO()).ToList()
            };

            return Ok(stockElementWrapper);
        }

        [HttpPut("/api/stockelements/increase")]
        public IActionResult Increase([FromBody] StockElementChangeDTO stockElement)
        {
            this.stockElementRepository.Increase(stockElement.PartId, stockElement.ChangedQuantity);
            return Ok();
        }

        [HttpPut("/api/stockelements/decrease")]
        public IActionResult Decrease([FromBody] StockElementChangeDTO stockElement)
        {
            this.stockElementRepository.Decrease(stockElement.PartId, stockElement.ChangedQuantity);
            return Ok();
        }

        [HttpPost("/api/stockelements/add")]
        public IActionResult Add([FromBody] StockElementChangeDTO stockElement)
        {
            this.stockElementRepository.Add(stockElement.PartId, stockElement.ChangedQuantity);
            return Ok();
        }

        [HttpDelete("/api/stockelements/delete")]
        public IActionResult Delete([FromBody] StockElementChangeDTO stockElement)
        {
            this.stockElementRepository.Delete(stockElement.PartId);
            return Ok();
        }
    }
}
