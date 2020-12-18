using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Models
{
    public class User : IdentityUser<Guid>
    {
        
        public string Name { get; set; }
       
        public string LastName { get; set; }
        
        public string DNI { get; set; }
        
        
    }
}
