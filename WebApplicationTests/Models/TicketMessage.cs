using System;

namespace WebApplicationTests.Models
{
    public class TicketMessage
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public Guid SupportTicketId { get; set; }
        public SupportTicket SupportTicket { get; set; }
    }
}