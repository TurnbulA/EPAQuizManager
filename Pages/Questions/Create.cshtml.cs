using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizManager.Data;
using QuizManager.Models;

namespace QuizManager.Pages.Questions
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
            ViewData["QuizName"] = new SelectList(_context.Quiz, "QuizName", "QuizName");
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Question.Add(Question);
            await _context.SaveChangesAsync();
            return Redirect($"/Quizzes/Details?id={Question.QuizRef}");

        }
    }
}
