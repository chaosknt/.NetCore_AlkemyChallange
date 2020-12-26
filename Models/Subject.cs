using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name= "Dia de cursada")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public DayOfTheWeek DayOfTheWeek { get; set; }

        [Display(Name = "Dia de cursada")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public Guid DayOfTheWeekId { get; set; }

        [Display(Name = "Hora de cursada")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public DateTime Hour { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [Display(Name = "Profesor")]        
        public Guid TeacherId { get; set; }

        [Display(Name = "Profesor")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public Teacher Teacher { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [Display(Name = "Cupo máximo")]
        public int MaxStudents { get; set; }

        public List<EnrolledStudents> EnrolledStudents { get; set; }
               
    }
}

