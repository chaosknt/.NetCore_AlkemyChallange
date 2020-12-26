using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Models
{
    public class Student : UserAcc
    {        
        public string Docket { get; set; }

        public List<EnrolledStudents> EnrolledSubjects { get; set; }
    }
}
