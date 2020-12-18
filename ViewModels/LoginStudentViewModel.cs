using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.ViewModels
{
    public class LoginStudentViewModel
    {
        [Required]
        public string DNI { get; set; }

        [Required]
        public string Docket { get; set; }
    }
}
