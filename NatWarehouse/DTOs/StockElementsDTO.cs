using System.Collections.Generic;

namespace WareHouseAPI.DTOs
{
    /// <summary>
    /// DTO for listing stock elements.
    /// </summary>
    public class StockElementsDTO
    {
        public List<StockElementDTO> StockElements { get; set; }
    }
}