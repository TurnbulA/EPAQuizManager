using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizManager.Models;

namespace QuizManager.Pages.Answers
{
    public class DeleteModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public DeleteModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Answer Answer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Answer = await _context.Answer.FirstOrDefaultAsync(m => m.AnswerId == id);

            if (Answer == null)
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

            Answer = await _context.Answer.FindAsync(id);
            var questionRef = Answer.QuestionRef;
            if (Answer != null)
            {
                _context.Answer.Remove(Answer);
                await _context.SaveChangesAsync();
            }

            return Redirect($"/Questions/Details?id={questionRef}");
        }
    }
}
