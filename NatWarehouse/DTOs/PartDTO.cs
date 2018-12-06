using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WareHouseAPI.DTOs
{
    /// <summary>
    /// DTO for transferring part object between the server - client
    /// </summary>
    public class PartDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public double PriceInEur { get; set; }

        public string Description { get; set; }

        public double Mass { get; set; }
    }
}
