using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Models;

namespace WebApplicationTests.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AnswerTheQuestion> AnswerTheQuestions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
