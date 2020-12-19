using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Models
{
    public class Subject
    {
        public Guid SubjectId { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(3, ErrorMessage = ValidationMessages.MinLength)]
        [MaxLength(12, ErrorMessage = ValidationMessages.MaxLength)]
        public string Name { get; set; }

        [Display(Name= "Dia y hora de cursada")]
        
        public DateTime Schedule { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]        
        public int MaxStudents { get; set; }

    }
}
