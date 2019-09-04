using StockInventory.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockInventory.Models
{
    public class Department
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "El departamento es requerido"), MaxLength(20)]
        [Display(Name = "Departamento")]
        public string Type { get; set; }
        
        [NotEmpty]
        [Display(Name = "Ciudad")]
        public Guid CityID { get; set; }

        public City City { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}