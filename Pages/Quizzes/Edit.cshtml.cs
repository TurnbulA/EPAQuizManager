using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuizManager.Data;
using QuizManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace QuizManager.Pages.Quizzes
{
    
    public class EditModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public EditModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = await _context.Quiz.FirstOrDefaultAsync(m => m.QuizId == id);

            if (Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(Quiz.QuizId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.QuizId == id);
        }
    }
}
