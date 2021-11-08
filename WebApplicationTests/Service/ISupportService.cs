using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Services
{
    public interface ISupportService
    {
        Task CreateSupportTicket(SupportTicket supportTicket);
        Task<IEnumerable<SupportTicket>> GetAllTicketsAsync();
    }

    public class SupportService : ISupportService
    {
        private readonly AppDb _db;

        public SupportService(AppDb db)
        {
            _db = db;
        }

        public async Task CreateSupportTicket(SupportTicket supportTicket)
        {
            await _db.SupportTickets.AddAsync(supportTicket);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<SupportTicket>> GetAllTicketsAsync()
        {
            return await _db.SupportTickets.ToListAsync();
        }
    }
}