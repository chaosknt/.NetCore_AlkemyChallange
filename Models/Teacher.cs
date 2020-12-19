using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Models
{
    public class Teacher
    {
        public Guid TeacherId { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(3,ErrorMessage = ValidationMessages.MinLength)]
        [MaxLength(12, ErrorMessage = ValidationMessages.MaxLength)]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(3, ErrorMessage = ValidationMessages.MinLength)]
        [MaxLength(12, ErrorMessage = ValidationMessages.MaxLength)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [Display(Name = "Documento")]
        [Remote(action: "DniExists", controller: "Teachers")]
        [RegularExpression(@"[0-9]{2}\.[0-9]{3}\.[0-9]{3}", ErrorMessage = "El campo {0} debe tener este formato NN.NNN.NNN")]
        public string DNI { get; set; }

        [Display(Name = "Es activo")]
        public Boolean isActive { get; set; } = true;
       
        public Guid SubjetId { get; set; }

    }
}
