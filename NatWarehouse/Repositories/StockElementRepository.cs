using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WareHouseAPI.Database;
using WareHouseAPI.Entities;
using NatWarehouse.Exceptions;

namespace NatWarehouse.Repositories
{
    /// <summary>
    /// Stock element repository implementation.
    /// </summary>
    public class StockElementRepository : IStockElementRepository
    {
        protected WarehouseDbContext context;

        public StockElementRepository(WarehouseDbContext context)
        {
            this.context = context;
        }

        public List<StockElementEntity> GetAll()
        {
            var stockElements = this.context.StockElements.Include(st => st.Part).ToList();
            return stockElements;
        }

        public void Increase(int partId, int quantity)
        {
            var stockElementToIncrease = this.context.StockElements.Include(st => st.Part).FirstOrDefault(el => el.PartId == partId);

            if (stockElementToIncrease == null)
            {
                var partToAdd = this.context.Parts.FirstOrDefault(el => el.Id == partId);
                if (partToAdd == null) {
                    throw new WarehouseApplicationException(ExceptionCode.InvalidState);
                }

                // Adding a new element if the part exists, but there was no element before.
                var stockElementToAdd = new StockElementEntity
                {
                    Part = partToAdd,
                    Quantity = quantity
                };

                this.context.Add(stockElementToAdd);

            } else {
                stockElementToIncrease.Quantity += quantity;
            }

            this.context.SaveChanges();
        }

        public void Decrease(int partId, int quantity)
        {
            var stockElementToDecrease = this.context.StockElements.Include(st => st.Part).FirstOrDefault(el => el.PartId == partId);

            if (stockElementToDecrease == null)
            {
                throw new WarehouseApplicationException(ExceptionCode.EntityNotFound);
            }

            if (stockElementToDecrease.Quantity - quantity < 0) {
                throw new WarehouseApplicationException(ExceptionCode.InvalidState);
            }

            // Removing element if there is no more remaining entry.
            if (stockElementToDecrease.Quantity - quantity == 0)
            {
                this.context.Remove(stockElementToDecrease);
            } else {
                stockElementToDecrease.Quantity -= quantity;
            }

            this.context.SaveChanges();
        }
    }
}
