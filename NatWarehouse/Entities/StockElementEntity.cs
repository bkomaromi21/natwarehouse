using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WareHouseAPI.DTOs;

namespace WareHouseAPI.Entities
{
    /// <summary>
    /// Entity class for accessing the stock elemnts table
    /// </summary>
    public class StockElementEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Part")]
        public int PartId { get; set; }

        [Required]
        public virtual PartEntity Part { get; set; }

        [Required]
        public int Quantity { get; set; }

        public StockElementDTO toDTO()
        {
            return new StockElementDTO
            {
                Part = this.Part.toDTO(),
                Quantity = this.Quantity
            };
        }

        public StockElementDTO toDTO(double? eurConversionRate)
        {
            return new StockElementDTO
            {
                Part = this.Part.toDTO(eurConversionRate),
                Quantity = this.Quantity
            };
        }
    }
}
