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
            var stockElementToIncrease = this.context.StockElements.Include(st => st.Part).Where(el => el.PartId == partId).FirstOrDefault();

            if (stockElementToIncrease == null)
            {
                throw new WarehouseApplicationException(ExceptionCode.EntityNotFound);
            }

            stockElementToIncrease.Quantity += quantity;

            this.context.SaveChanges();
        }

        public void Decrease(int partId, int quantity)
        {
            var stockElementToDecrease = this.context.StockElements.Include(st => st.Part).Where(el => el.PartId == partId).FirstOrDefault();

            if (stockElementToDecrease == null)
            {
                throw new WarehouseApplicationException(ExceptionCode.EntityNotFound);
            }

            if (stockElementToDecrease.Quantity - quantity < 0) {
                throw new WarehouseApplicationException(ExceptionCode.InvalidState);
            }

            stockElementToDecrease.Quantity -= quantity;

            this.context.SaveChanges();
        }

        public void Add(int partId, int quantity)
        {
            var stockElementToAdd = this.context.StockElements.FirstOrDefault(el => el.PartId == partId);
            var partToAdd = this.context.Parts.FirstOrDefault(part => part.Id == partId);

            if (stockElementToAdd != null || partToAdd == null)
            {
                throw new WarehouseApplicationException(ExceptionCode.InvalidState);
            }

            stockElementToAdd = new StockElementEntity
            {
                Part = partToAdd,
                Quantity = quantity
            };

            this.context.Add(stockElementToAdd);
            this.context.SaveChanges();
        }

        public void Delete(int partId)
        {
            var stockElementToDelete = this.context.StockElements.FirstOrDefault(el => el.PartId == partId);

            if (stockElementToDelete == null)
            {
                throw new WarehouseApplicationException(ExceptionCode.EntityNotFound);
            }

            this.context.Remove(stockElementToDelete);
            this.context.SaveChanges();
        }
    }
}
