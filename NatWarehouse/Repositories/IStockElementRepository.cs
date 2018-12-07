using System;
using System.Collections.Generic;
using WareHouseAPI.Entities;

namespace NatWarehouse.Repositories
{
    /// <summary>
    /// Stock element repository for accessing stock element entities.
    /// </summary>
    public interface IStockElementRepository
    {
        List<StockElementEntity> GetAll();

        void Increase(int partId, int quantity);

        void Decrease(int partId, int quantity);

        void Add(int partId, int quantity);

        void Delete(int partId);

    }
}
