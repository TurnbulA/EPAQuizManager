using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManager.Models
{
    public class UserLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Password error try again")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string InputPassword { get; set; }
        [Required(ErrorMessage = "Username error try again")]
        [Display(Name = "Username")]
        public string InputUserName { get; set; }
        [Required(ErrorMessage = "Access error try again")]
        public string Access { get; set; }
    }
}
