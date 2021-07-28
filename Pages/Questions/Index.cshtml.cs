using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizManager.Data;
using QuizManager.Models;

namespace QuizManager.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public IndexModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }
        public string QuestionSort { get; set; }
        public string QuizSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Question> Questions { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //using System;
            QuestionSort = String.IsNullOrEmpty(sortOrder) ? "question_desc" : "";
            QuizSort = sortOrder == "Quiz" ? "quiz_desc" : "Quiz";

            CurrentFilter = searchString;

            IQueryable<Question> questionsIQ = from q in _context.Question
                                              select q;
            if (!String.IsNullOrEmpty(searchString))
            {
                questionsIQ = questionsIQ.Where(q => q.QuizName.Contains(searchString) || q.QuestionContent.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "question_desc":
                    questionsIQ = questionsIQ.OrderByDescending(q => q.QuestionContent);
                    break;
                case "Quiz":
                    questionsIQ = questionsIQ.OrderBy(q => q.QuizName);
                    break;
                case "quiz_desc":
                    questionsIQ = questionsIQ.OrderByDescending(q => q.QuizName);
                    break;
                default:
                    questionsIQ = questionsIQ.OrderBy(q => q.QuestionContent);
                    break;
            }
            Questions = await questionsIQ.AsNoTracking().ToListAsync();
        }
    }
}
