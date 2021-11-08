using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Models
{
    public class SupportTicket
    {
        public Guid Id { get; set; }
        public string Submit { get; set; }
        public string Description { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserName { get; set; }
        public List<TicketMessage> TicketMessages { get; set; }
        public bool isFAQ { get; set; }
    }
}
