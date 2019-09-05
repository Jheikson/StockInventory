using System;
using System.ComponentModel.DataAnnotations;

namespace StockInventory.Models
{
    public class Employee
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "La cédula es requerida")]
        [Display(Name = "Cédula")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(20)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es requerido"), MaxLength(20)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La gerencia es requerida"), MaxLength(30)]
        [Display(Name = "Gerencia")]
        public string Gerency { get; set; }

        [Required(ErrorMessage = "El departamento es requerido"), MaxLength(30)]
        [Display(Name = "Departamento")]
        public string Deparment { get; set; }

        [Required(ErrorMessage = "El cargo es requerido"), MaxLength(40)]
        [Display(Name = "Cargo")]
        public string Charge { get; set; }

        [Display(Name = "Activo")]
        public bool Status { get; set; }

        [Display(Name = "Oficina")]
        public Guid OfficeID { get; set; }

        public Office Office { get; set; }
    }
}