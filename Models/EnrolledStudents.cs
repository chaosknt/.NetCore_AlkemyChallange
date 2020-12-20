using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Models
{
    public class EnrolledStudents
    {
        public Guid EnrolledStudentsId { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subcject { get; set; }
    }
}
