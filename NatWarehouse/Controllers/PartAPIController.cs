using Microsoft.AspNetCore.Mvc;
using WareHouseAPI.DTOs;
using System.Linq;
using NatWarehouse.Controllers;
using NatWarehouse.Repositories;
using NatWarehouse.DTOs;

namespace WareHouseAPI.Controllers
{
    /// <summary>
    /// Controller class for CRUD operations on the parts
    /// </summary>
    public class PartAPIController : WarehouseController
    {
        IPartRepository partRepository;

        public PartAPIController(IPartRepository partRepository) {
            this.partRepository = partRepository;
        }

        [HttpPost("/api/parts/create")]
        public IActionResult Create([FromBody] PartDTO part)
        {
            this.partRepository.Create(part.Description, part.Mass, part.Price);
            return Ok();
        }

        [HttpGet("/api/parts/getall")]
        public IActionResult Read()
        {
            var parts = this.partRepository.Read().Select(part => part.toDTO()).ToList();
            var partWrapper = new PartsDTO
            {
                Parts = parts
            };

            return Ok(partWrapper);
        }

        [HttpPut("/api/parts/modify")]
        public IActionResult Update([FromBody] PartDTO part)
        {
            this.partRepository.Update(part.Id, part.Description, part.Mass, part.Price);
            return Ok();
        }

        [HttpDelete("/api/parts/delete")]
        public IActionResult Delete([FromBody] PartDTO part)
        {
            this.partRepository.Delete(part.Id);
            return Ok();
        }
    }
}
