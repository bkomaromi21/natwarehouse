using Microsoft.AspNetCore.Mvc;

namespace WareHouseAPI.DTOs
{
    /// <summary>
    /// DTO for changin the stock elements.
    /// </summary>
    public class StockElementChangeDTO : Controller
    {
        public int PartId { get; set; }

        public int ChangedQuantity { get; set; }
    }
}
