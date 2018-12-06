namespace WareHouseAPI.DTOs
{
    /// <summary>
    /// DTO for listing stock element items.
    /// </summary>
    public class StockElementDTO
    {
        public PartDTO Part { get; set; }

        public int Quantity { get; set; }
    }
}
