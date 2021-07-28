using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizManager.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        [Display(Name = "Quiz Name")]
        [Required]
        public string QuizName { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
