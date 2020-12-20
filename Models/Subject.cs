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
        [Display(Name = "Materia")]
        public string Name { get; set; }

        [Display(Name= "Dia de cursada")]       
        public DayOfTheWeek DayOfTheWeek { get; set; }
        public Guid DayOfTheWeekId { get; set; }

        [Display(Name = "Hora de cursada")]
        [DataType(DataType.Time)]
        public DateTime Hour { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]        
        public Guid TeacherId { get; set; }

        [Display(Name = "Profesor")]
        public Teacher Teacher { get; set; }

        [Required]        
        [Display(Name = "Cupo")]
        public int MaxStudents { get; set; }

    }
}

