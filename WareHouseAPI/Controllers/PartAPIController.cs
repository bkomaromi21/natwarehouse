using Microsoft.AspNetCore.Mvc;
using WareHouseAPI.Database;
using WareHouseAPI.DTOs;
using System.Linq;
using WareHouseAPI.Entities;

namespace WareHouseAPI.Controllers
{

    /// <summary>
    /// Controller class for CRUD operations on the parts
    /// </summary>
    public class PartAPIController : BaseAPIController
    {
        public PartAPIController(WarehouseDbContext context) : base(context) { }

        [HttpPost("/api/parts/create")]
        public IActionResult Create([FromBody] PartDTO part)
        {
            var partToCreate = new PartEntity
            {
                Description = part.Description,
                Mass = part.Mass,
                Price = part.Price
            };

            this.context.Add(partToCreate);
            this.context.SaveChanges();

            return Ok();
        }

        [HttpGet("/api/parts/getall")]
        public IActionResult Read()
        {
            return Ok(this.context.Parts);
        }

        [HttpPut("/api/parts/modify")]
        public IActionResult Update([FromBody] PartDTO part)
        {
            var partToModify = this.context.Parts.Find(part.Id);

            if (partToModify == null) {
                return NotFound();
            }

            partToModify.Description = part.Description;
            partToModify.Mass = part.Mass;
            partToModify.Price = part.Price;

            this.context.SaveChanges();

            return Ok();
        }

        [HttpDelete("/api/parts/delete")]
        public IActionResult Delete([FromBody] PartDTO part)
        {
            var partToDelete = this.context.Parts.Find(part.Id);

            if (partToDelete == null)
            {
                return NotFound();
            }

            this.context.Remove(partToDelete);
            this.context.SaveChanges();

            return Ok();
        }
    }
}
