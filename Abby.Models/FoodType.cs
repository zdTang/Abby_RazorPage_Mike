﻿using System.ComponentModel.DataAnnotations;

namespace Abby.Models
{
    public class FoodType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
    }
}
