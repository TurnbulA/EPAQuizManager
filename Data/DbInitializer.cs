using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QuizManager.Models;
namespace QuizManager.Data
{
    public class DbInitializer
    {
        static string Hash(string pass)
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
        public static void Initialize(UserContext context)
        {
            if (context.User.Any())
            {
                return;
            };

            var users = new User[]
            {
                new User
                {
                    Username = "Restricted", FirstName = "User", LastName = "One", Password = Hash("Restricted"),
                    Access = "Restricted"
                },
                new User {Username = "View", FirstName = "User", LastName = "Two", 
                    Password = Hash("View"), Access = "View"},
                new User {Username = "Edit", FirstName = "User", LastName = "Three", 
                    Password = Hash("Edit"), Access = "Edit"}
            };
            context.User.AddRange(users);
            context.SaveChanges();
        }

        
    }
}
