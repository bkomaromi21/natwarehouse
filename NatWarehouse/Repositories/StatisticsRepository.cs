﻿using System;
using System.Linq;
using WareHouseAPI.Database;
using WareHouseAPI.Entities;

namespace NatWarehouse.Repositories
{
    /// <summary>
    /// Statistics repository implementation.
    /// </summary>
    public class StatisticsRepository : IStatisticsRepository
    {
        WarehouseDbContext context;

        public StatisticsRepository(WarehouseDbContext context)
        {
            this.context = context;
        }

        public PartEntity GetHeaviestPart()
        {
            var stockElements = this.context.StockElements;
            return stockElements.Aggregate((currentHeaviest, x) => (currentHeaviest == null || x.Part.Mass > currentHeaviest.Part.Mass ? x : currentHeaviest)).Part;
        }

        public PartEntity GetMostFrequentPart()
        {
            var stockElements = this.context.StockElements;
            var mostFrequentPart = stockElements.Aggregate((currentHeaviest, x) => (currentHeaviest == null || x.Quantity > currentHeaviest.Quantity ? x : currentHeaviest)).Part;

            return mostFrequentPart;
        }

        public double GetSumMass()
        {
            var stockElements = this.context.StockElements;
            return stockElements.Select(el => el.Part.Mass * el.Quantity).Sum();
        }

        public double GetSumPrice()
        {
            var stockElements = this.context.StockElements;
            return stockElements.Select(el => el.Part.Price * el.Quantity).Sum();
        }
    }
}
