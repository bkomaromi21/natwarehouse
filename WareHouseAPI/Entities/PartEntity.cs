using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WareHouseAPI.DTOs;

namespace WareHouseAPI.Entities
{
    /// <summary>
    /// Entity class for accessing the parts table
    /// </summary>
    public class PartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public double Mass { get; set; }

        public StockElementEntity Inventory { get; set; }

        public PartDTO toDTO() {
            return new PartDTO
            {
                Name = this.Name,
                Price = this.Price,
                Description = this.Description,
                Mass = this.Mass
            };
        }
    }
}
