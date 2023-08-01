using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abby.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Range(1, 1000, ErrorMessage = "Price should be between $1 and $1000")]
        public double Price { get; set; }
        public int FoodTypeId { get; set; }
        [ForeignKey("FoodTypeId")]  // Use this Attribute to denote this is a Foreign Key
        public FoodType FoodType { get; set; } // Add a Navigation property, Or the Foreign Key will not be recognized
        public int CategoryId { get; set; }//As this propertyName is Category+Id, the entityFramework will regard it as Foreign key
        public Category Category { get; set; } // Add a Navigation property, Or the Foreign Key will not be recognized
    }
}
