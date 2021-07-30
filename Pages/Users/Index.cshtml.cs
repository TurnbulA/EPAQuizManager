using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuizManager.Data;
using QuizManager.Models;


namespace QuizManager.Pages.Users
{
    public class IndexModel : PageModel
    {
        public string Hash(string pass)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString(("X2")));
                }

                return sb.ToString();
            }
        }
        private readonly UserContext _context;
        public IndexModel(UserContext context)
        {
            _context = context;

        }

        [BindProperty]
        public UserLogin UserLogin { get; set; }
        public User User { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var newUser = UserLogin;
            
            _context.UserLogin.Attach(UserLogin);
            await _context.SaveChangesAsync();
            User = await _context.User.FirstOrDefaultAsync(m => m.Username == UserLogin.InputUserName);
            bool userCheck = UserLogin.InputUserName == User.Username;
            var inputPass = Hash(UserLogin.InputPassword);
            bool passCheck = inputPass == User.Password;
            bool accessCheck = UserLogin.Access == User.Access; 
            if (userCheck && passCheck && accessCheck){

                return Redirect("/Quizzes/Index"); 
            }
            else
            {
                throw new Exception("Failed login");
                return Page();
            }
            
        }
    }


}
