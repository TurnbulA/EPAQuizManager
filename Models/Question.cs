using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizManager.Models
{
    public class Question
    {
        public int ID { get; set; }
        [Display(Name = "Question")]
        public string QuestionContent { get; set; }
        [Display(Name = "Quiz Title")]
        public string QuizName { get; set; }
        [Display (Name = "Quiz Id")]
        public int QuizRef { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<Answer> Answers  { get; set; }
    }
}
