using StockInventory.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockInventory.Models
{
    public class Item
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "El tipo es requerido"), MaxLength(30)]
        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Required(ErrorMessage = "La marca es requerida"), MaxLength(30)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [MaxLength(30)]
        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Display(Name = "Activo")]
        public bool Status { get; set; }

        [MaxLength(100)]
        [Display(Name = "Observación")]
        public string Observation { get; set; }

        [NotEmpty]
        [Display(Name = "Oficina")]
        public Guid OfficeID { get; set; }

        public Office Office { get; set; }

        [Display(Name = "Asignado a")]
        public Guid? EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }
}