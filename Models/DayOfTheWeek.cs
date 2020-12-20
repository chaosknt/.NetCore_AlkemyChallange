using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Models
{
    public class DayOfTheWeek
    {
        public Guid DayOfTheWeekId { get; set; }
        [Required]
        public string Name { get; set; }
       
    }
}
