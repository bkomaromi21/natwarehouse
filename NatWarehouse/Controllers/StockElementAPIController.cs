﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NatWarehouse.Controllers;
using NatWarehouse.Repositories;
using NatWarehouse.Services;
using WareHouseAPI.DTOs;

namespace WareHouseAPI.Controllers
{
    /// <summary>
    /// Controller class for CRUD operations on the stock elements
    /// </summary>
    public class StockElementAPIController: WarehouseController
    {
        IStockElementRepository stockElementRepository;
        ICurrencyService currencyService;

        public StockElementAPIController(IStockElementRepository stockElementRepository, ICurrencyService currencyService) {
            this.stockElementRepository = stockElementRepository;
            this.currencyService = currencyService;
        }

        [HttpGet("/api/stockelements/getall")]
        public IActionResult GetAll()
        {
            var conversionRate = this.currencyService.GetExchangeRate("eur", false);

            var stockElements = this.stockElementRepository.GetAll();

            var stockElementWrapper = new StockElementsDTO
            {
                StockElements = stockElements.Select(el => el.toDTO(conversionRate)).ToList()
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
    }
}
