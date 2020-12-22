using AlkemyChallange.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = ValidationMessages.Required)]
        [Display(Name = "Número de documento")]
        [RegularExpression(@"[0-9]{2}\.[0-9]{3}\.[0-9]{3}", ErrorMessage = "El campo {0} debe tener este formato NN.NNN.NNN")]
        public string DNI { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [Display(Name = "Legajo")]
        public string Docket { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [Display(Name = "Rol")]
        public Role Role { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [Display(Name = "Rol")]
        public Guid RoleId { get; set; }
               

    }
}
