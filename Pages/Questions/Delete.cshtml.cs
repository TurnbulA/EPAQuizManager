using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizManager.Data;
using QuizManager.Migrations;
using QuizManager.Models;

namespace QuizManager.Pages.Questions
{
    public class DeleteModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public DeleteModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Question Question { get; set; }
        public IList<Answer> Answer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Question.FirstOrDefaultAsync(m => m.ID == id);
            Answer = await _context.Answer.ToListAsync();
            if (Question == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Question.FindAsync(id);
            Answer = await _context.Answer.ToListAsync();
            var quizRef = Question.QuizRef; 
            if (Question != null)
            {
                foreach (var answer in Answer)
                {
                    _context.Answer.Remove(answer);
                }
                _context.Question.Remove(Question);
                await _context.SaveChangesAsync();
            }

            return Redirect($"/Quizzes/Details?id={quizRef}");
        }
    }
}
