using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WareHouseAPI.Entities;

namespace WareHouseAPI.Database
{
    /// <summary>
    /// Warehouse database context.
    /// </summary>
    public class WarehouseDbContext : DbContext
    {
        public DbSet<PartEntity> Parts { get; set; }

        public DbSet<StockElementEntity> StockElements { get; set; }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StockElementEntity>()
                        .HasOne(c => c.Part)
                        .WithOne(e => e.Inventory);
        }
    }
}
