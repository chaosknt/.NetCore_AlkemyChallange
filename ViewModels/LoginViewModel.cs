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
        public string DNI { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Docket { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public Role Role { get; set; }
    }
}
