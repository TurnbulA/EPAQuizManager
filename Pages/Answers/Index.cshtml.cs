using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizManager.Data;
using QuizManager.Models;

namespace QuizManager.Pages.Answers
{
    public class IndexModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public IndexModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

        public IList<Answer> Answer { get;set; }

        public async Task OnGetAsync()
        {
            Answer = await _context.Answer.ToListAsync();
        }
    }
}
