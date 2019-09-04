using StockInventory.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockInventory.Models
{
    public class User
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "El usuario es requerido"), MaxLength(20)]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es requerida"), MaxLength(15)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe confirmar la contraseña"), MaxLength(15)]
        [Compare("Password", ErrorMessage = "Las contraseñas no concuerdan")]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; }

        [NotEmpty]
        [Display(Name = "Empleado")]
        public Guid EmployeeID { get; set; }

        public Employee Employee { get; set; }
    }
}