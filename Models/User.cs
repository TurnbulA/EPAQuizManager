using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        public string Username { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Access { get; set; }
        public string Status { get; set; }
    }
}
