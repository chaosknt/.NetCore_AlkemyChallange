using AlkemyChallange.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(3, ErrorMessage = ValidationMessages.MinLength)]
        [MaxLength(12, ErrorMessage = ValidationMessages.MaxLength)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(3, ErrorMessage = ValidationMessages.MinLength)]
        [MaxLength(12, ErrorMessage = ValidationMessages.MaxLength)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [RegularExpression(@"[0-9]{2}\.[0-9]{3}\.[0-9]{3}", ErrorMessage = "El campo {0} debe tener este formato NN.NNN.NNN")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [Display(Name = "Número de documento")]
        public string DNI { get; set; }
    }
}
