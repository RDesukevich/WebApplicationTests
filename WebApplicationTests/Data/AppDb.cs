using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Models;

namespace WebApplicationTests.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Section> Sections { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerTheQuestion> Answers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<AboutYou> AboutYous { get; set; }
    }
}
