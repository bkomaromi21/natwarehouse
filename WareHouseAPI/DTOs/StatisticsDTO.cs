namespace WareHouseAPI.DTOs
{
    /// <summary>
    /// DTO for transfering statistics report
    /// </summary>
    public class StatisticsDTO
    {
        public double SumMass { get; set; }

        public double SumPrice { get; set; }

        public PartDTO MostFrequentPart { get; set; }

        public PartDTO HeaviestPart { get; set; }
    }
}
