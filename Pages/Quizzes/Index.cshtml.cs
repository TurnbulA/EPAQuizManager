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

        public IndexModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

        public IList<Quiz> Quiz { get;set; }

        public async Task OnGetAsync()
        {
            Quiz = await _context.Quiz.ToListAsync();
        }
    }
}
