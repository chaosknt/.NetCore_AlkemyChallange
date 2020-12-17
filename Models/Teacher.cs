using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(3, ErrorMessage = ValidationMessages.MinLength)]
        [MaxLength(12, ErrorMessage = ValidationMessages.MaxLength)]        
        public string LastName { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string DNI { get; set; }

        public Boolean isActive { get; set; } = true;
    }
}
