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

namespace QuizManager.Pages.Login
{
    public class CreateModel : PageModel
    {
        private readonly QuizManager.Data.UserContext _context;

        public CreateModel(QuizManager.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserLogin UserLogin { get; set; }
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserLogin = await _context.UserLogin.FirstOrDefaultAsync(m => m.LoginId == id);

            if (UserLogin == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var passCheck = false;
            var userCheck = false;
            _context.UserLogin.Add(UserLogin);
            await _context.SaveChangesAsync();
            foreach (var pass in User.Password)
            {
                passCheck = BCrypt.Net.BCrypt.Verify(UserLogin.InputPassword, User.Password);
            }
            foreach (var username in User.Username)
            {
                if (UserLogin.InputUserName == User.Username)
                {
                    userCheck = true;
                }
            }

            if (userCheck && passCheck)
            {
                _context.UserLogin.Remove(UserLogin);
                return Redirect("/Quizzes/Index");
            }
            return NotFound();
        }
    }
}
