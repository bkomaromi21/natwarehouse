using System;
using System.Collections.Generic;
using WareHouseAPI.DTOs;

namespace NatWarehouse.DTOs
{
    /// <summary>
    /// DTO for listing part elements.
    /// </summary>
    public class PartsDTO
    {
        public List<PartDTO> Parts { get; set; }
    }
}
