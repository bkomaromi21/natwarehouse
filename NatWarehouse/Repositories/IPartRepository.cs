using System;
using System.Collections.Generic;
using WareHouseAPI.Entities;

namespace NatWarehouse.Repositories
{
    /// <summary>
    /// Part repository for accessing part entities.
    /// </summary>
    public interface IPartRepository
    {
        void Create(string description, double mass, int price);

        List<PartEntity> Read();

        void Update(int partId, string description, double mass, int price);

        void Delete(int partId);
    }
}
