using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizManager.Models;

namespace QuizManager.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext (DbContextOptions<QuizContext> options)
            : base(options)
        {
        }

        public DbSet<QuizManager.Models.Question> Question { get; set; }
        public DbSet<QuizManager.Models.Quiz> Quiz { get; set; }
        public DbSet<QuizManager.Models.Answer> Answer { get; set; }


    }
}
