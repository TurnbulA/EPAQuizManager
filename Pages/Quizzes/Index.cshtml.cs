using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizManager.Data;
using QuizManager.Models;

namespace QuizManager.Pages.Quizzes
{
    public class IndexModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;
        private readonly QuizManager.Data.UserContext _userContext;
        public string QuizSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IndexModel(QuizManager.Data.QuizContext context, QuizManager.Data.UserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }
        

        public IList<Quiz> Quiz { get;set; }
        public UserLogin UserLogin { get; set; }
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            QuizSort = sortOrder == "Quiz" ? "quiz_desc" : "Quiz";

            CurrentFilter = searchString;

            IQueryable<Quiz> quizIQ = from q in _context.Quiz
                select q;
            if (!String.IsNullOrEmpty(searchString))
            {
                quizIQ = quizIQ.Where(q => q.QuizName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Quiz":
                    quizIQ = quizIQ.OrderBy(q => q.QuizName);
                    break;
                case "quiz_desc":
                    quizIQ = quizIQ.OrderByDescending(q => q.QuizName);
                    break;
            }
            Quiz = await quizIQ.AsNoTracking().ToListAsync();
            
        }
    }
}
