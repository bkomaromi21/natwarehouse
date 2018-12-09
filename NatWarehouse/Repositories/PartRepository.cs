using System;
using System.Linq;
using System.Collections.Generic;
using WareHouseAPI.Database;
using WareHouseAPI.Entities;
using NatWarehouse.Exceptions;

namespace NatWarehouse.Repositories
{
    /// <summary>
    /// Part repository implementation.
    /// </summary>
    public class PartRepository : IPartRepository
    {
        WarehouseDbContext context;

        public PartRepository(WarehouseDbContext context)
        {
            this.context = context;
        }

        public void Create(string name, string description, double mass, int price)
        {
            var partToCreate = new PartEntity
            {
                Name = name,
                Description = description,
                Mass = mass,
                Price = price
            };

            this.context.Add(partToCreate);
            this.context.SaveChanges();
        }

        public List<PartEntity> Read()
        {
            return this.context.Parts.ToList();
        }

        public PartEntity Read(int id)
        {
            return this.context.Parts.FirstOrDefault(part => part.Id == id);
        }

        public void Update(int partId, string name, string description, double mass, int price)
        {
            var partToModify = this.context.Parts.Find(partId);

            if (partToModify == null) {
                throw new WarehouseApplicationException(ExceptionCode.EntityNotFound);
            }

            partToModify.Name = name;
            partToModify.Description = description;
            partToModify.Mass = mass;
            partToModify.Price = price;

            this.context.SaveChanges();
        }

        public void Delete(int partId)
        {
            var partToDelete = this.context.Parts.Find(partId);

            if (partToDelete == null)
            {
                throw new WarehouseApplicationException(ExceptionCode.EntityNotFound);
            }

            this.context.Remove(partToDelete);
            this.context.SaveChanges();
        }
    }
}
