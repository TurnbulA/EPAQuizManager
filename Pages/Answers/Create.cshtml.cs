using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizManager.Data;
using QuizManager.Models;

namespace QuizManager.Pages.Answers
{
    public class CreateModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public CreateModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["QuestionContent"] = new SelectList(_context.Question, "QuestionContent", "QuestionContent");
            ViewData["QuizName"] = new SelectList(_context.Quiz, "QuizName", "QuizName");
            return Page();
        }

        [BindProperty]
        public Answer Answer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Answer.Add(Answer);
            await _context.SaveChangesAsync();

            return Redirect($"/Questions/Details?id={Answer.QuestionRef}");
        }
    }
}
