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
    public class DetailsModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public DetailsModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

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
    }
}
