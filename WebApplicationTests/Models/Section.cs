using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Models
{
    public class Section
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Test> Tests { get; set; } = new List<Test>();
    }
}
