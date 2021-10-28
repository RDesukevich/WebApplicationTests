using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Models
{
    public class FAQ
    {
        public Guid Id { get; set; }
        public Guid HeaderId { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }
    }
}
