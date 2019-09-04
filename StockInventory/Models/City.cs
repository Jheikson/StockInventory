using StockInventory.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockInventory.Models
{
    public class City
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "El nombre de la ciudad es requerido"), MaxLength(30)]
        [Display(Name = "Ciudad")]
        public string Name { get; set; }

        [NotEmpty]
        [Display(Name = "Región")]
        public Guid RegionID { get; set; }

        public Region Region { get; set; }
        
        public ICollection<Department> Departments { get; set; }
    }
}