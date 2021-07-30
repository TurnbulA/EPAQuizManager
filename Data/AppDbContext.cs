using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizManager.Models;

namespace QuizManager.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        #region Quiz Control
        public virtual async Task<List<Quiz>> GetQuizzesAsync()
        {
            return await Quizzes
                .OrderBy(quiz => quiz.QuizId)
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task AddQuizAsync(Quiz quiz)
        {
            await Quizzes.AddAsync(quiz);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAllQuizzesAsync()
        {
            foreach (var quiz in Quizzes)
            {
                Quizzes.Remove(quiz);
            }

            await SaveChangesAsync();
        }

        public virtual async Task DeleteQuizAsync(int id)
        {
            var quiz = await Quizzes.FindAsync(id);
            if (quiz != null)
            {
                Quizzes.Remove(quiz);
                await SaveChangesAsync();
            }
        }

        #endregion

        #region User Control
        public virtual async Task<List<User>> GetUsersAsync()
        {
            return await Users
                .OrderBy(user => user.UserId)
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task AddUserAsync(User user)
        {
            await Users.AddAsync(user);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAllUsersAsync()
        {
            foreach (var user in Users)
            {
                Users.Remove(user);
            }

            await SaveChangesAsync();
        }

        public virtual async Task DeleteUserAsync(int id)
        {
            var user = await Users.FindAsync(id);
            if (user != null)
            {
                Users.Remove(user);
                await SaveChangesAsync();
            }
        }


        #endregion
        public void Initialize()
        {
            Quizzes.AddRange(GetSeedingQuizzes());
            Users.AddRange(GetSeedingUsers());
        }
        
        public static List<Quiz> GetSeedingQuizzes()
        {
            return new List<Quiz>()
            {
                new Quiz(){QuizId = 1,QuizName = "Test 1",Questions = {},Answers = {}},
                new Quiz(){QuizId = 2,QuizName = "Test 2",Questions = {},Answers = {}},
                new Quiz(){QuizId = 3,QuizName = "Test 3",Questions = {},Answers = {}},
                new Quiz(){QuizId = 4,QuizName = "Test 4",Questions = {},Answers = {}},
                new Quiz(){QuizId = 5,QuizName = "Test 5",Questions = {},Answers = {}},
            };

        }

        

        public static List<User> GetSeedingUsers()
        {
            return new()
            {
                new User {UserId = 1,Username = "Test 1",FirstName = "User1",LastName = "Name1",Password = "Pass",Access = "admin"},
                new User {UserId = 2,Username = "Test 2",FirstName = "User2",LastName = "Name2",Password = "Pass",Access = "user"},
                new User {UserId = 3,Username = "Test 3",FirstName = "User3",LastName = "Name3",Password = "Pass",Access = "read"},
                new User {UserId = 4,Username = "Test 4",FirstName = "User4",LastName = "Name4",Password = "Pass",Access = "admin"},
                new User {UserId = 5,Username = "Test 5",FirstName = "User5",LastName = "Name5",Password = "Pass",Access = "read"},
            };
        }
    }
}
