using StockInventory.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockInventory.Models
{
    public class Office
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(30)]
        [Display(Name = "Oficina")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El código es requerido"), MaxLength(5)]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required(ErrorMessage = "La dirección es requerida"), MaxLength(100)]
        [Display(Name = "Dirección")]
        public string Direction { get; set; }

        [NotEmpty]
        [Display(Name = "Ciudad")]
        public Guid CityID { get; set; }

        public City City { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}