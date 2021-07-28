using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizManager.Models
{
    public class Answer
    {
        
        public int AnswerId { get; set; }
        [Display(Name = "Answer")]
        public string AnswerContent { get; set; }
        [Display(Name = "Answer Type")]
        public string AnswerType { get; set; }
        [Display(Name = "Question")]
        public string QuestionContent { get; set; }
        [Display(Name ="Quiz")]
        public string QuizName { get; set; }
        [Display (Name = "Question Id")]
        public int QuestionRef { get; set; }
<<<<<<< Updated upstream
        public Question Question { get; set; }
        public Quiz Quiz { get; set; }
=======
        //public Question Question { get; set; }
        //public Quiz Quiz { get; set; }
>>>>>>> Stashed changes
    }
}
