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
        [Display(Name = "Food Type")]            // The FoodType dropdown list will map to this property "FoodTypeId", but we don't want "FoodTypeId" as a Lable
        public int FoodTypeId { get; set; }
        [ForeignKey("FoodTypeId")]             // Use this Attribute to denote this is a Foreign Key
        public FoodType FoodType { get; set; } // Add a Navigation property, Or the Foreign Key will not be recognized
        [Display(Name = "Category")]           // The Category dropdown list will map to this property "CategoryId",  but we don't want "CategoryId" as a Lable
        public int CategoryId { get; set; }//As this propertyName is Category+Id, the entityFramework will regard it as Foreign key
        public Category Category { get; set; } // Add a Navigation property, Or the Foreign Key will not be recognized
    }
}
