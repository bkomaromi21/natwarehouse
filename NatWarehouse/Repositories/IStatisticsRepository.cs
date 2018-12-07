using System;
using WareHouseAPI.Entities;

namespace NatWarehouse.Repositories
{
    /// <summary>
    /// Statistics repository for accessing statistics information.
    /// </summary>
    public interface IStatisticsRepository
    {
        PartEntity GetHeaviestPart();

        PartEntity GetMostFrequentPart();

        double GetSumMass();

        double GetSumPrice();
    }
}
