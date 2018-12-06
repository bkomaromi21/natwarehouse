using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WareHouseAPI.Database;
using WareHouseAPI.DTOs;
using WareHouseAPI.Entities;

namespace WareHouseAPI.Controllers
{
    /// <summary>
    /// Controller class for CRUD operations on the stock elements
    /// </summary>
    public class StockElementAPIController : BaseAPIController
    {
        public StockElementAPIController(WarehouseDbContext context) : base(context) { }

        [HttpGet("/api/stockelements/getall")]
        public IActionResult GetAll()
        {
            var stockElements = this.context.StockElements.Include(st => st.Part).ToList();

            var stockElementWrapper = new StockElementsDTO
            {
                StockElements = stockElements.Select(el => el.toDTO()).ToList()
            };

            return Ok(stockElementWrapper);
        }

        [HttpPut("/api/stockelements/increase")]
        public IActionResult Increase([FromBody] StockElementChangeDTO stockElement)
        {
            var stockElementToIncrease = this.context.StockElements.Where(el => el.PartId == stockElement.PartId).FirstOrDefault();

            if (stockElementToIncrease == null) {
                return NotFound();
            }

            stockElementToIncrease.Quantity += stockElement.ChangedQuantity;

            this.context.SaveChanges();

            return Ok();
        }

        [HttpPut("/api/stockelements/decrease")]
        public IActionResult Decrease([FromBody] StockElementChangeDTO stockElement)
        {
            var stockElementToIncrease = this.context.StockElements.Where(el => el.PartId == stockElement.PartId).FirstOrDefault();

            if (stockElementToIncrease == null)
            {
                return NotFound();
            }

            stockElementToIncrease.Quantity -= stockElement.ChangedQuantity;

            this.context.SaveChanges();

            return Ok();
        }

        [HttpPost("/api/stockelements/add")]
        public IActionResult Add([FromBody] StockElementChangeDTO stockElement)
        {
            var stockElementToAdd = this.context.StockElements.FirstOrDefault(el => el.PartId == stockElement.PartId);
            var partToAdd = this.context.Parts.FirstOrDefault(part => part.Id == stockElement.PartId);

            if (stockElementToAdd != null || partToAdd == null)
            {
                return BadRequest();
            }

            stockElementToAdd = new StockElementEntity
            {
                Part = partToAdd,
                Quantity = stockElement.ChangedQuantity
            };

            this.context.Add(stockElementToAdd);
            this.context.SaveChanges();

            return Ok();
        }

        [HttpDelete("/api/stockelements/delete")]
        public IActionResult Delete([FromBody] StockElementChangeDTO stockElement)
        {
            var stockElementToDelete = this.context.StockElements.FirstOrDefault(el => el.PartId == stockElement.PartId);

            if (stockElementToDelete == null) {
                return NotFound();
            }

            this.context.Remove(stockElementToDelete);
            this.context.SaveChanges();

            return Ok();
        }
    }
}
