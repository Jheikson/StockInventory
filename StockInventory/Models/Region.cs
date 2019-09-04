using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockInventory.Models
{
    public class Region
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "El nombre de la región es requerido"), MaxLength(20)]
        [Display(Name = "Región")]
        public string Name { get; set; }

        public ICollection<City> City { get; set; }
    }
}