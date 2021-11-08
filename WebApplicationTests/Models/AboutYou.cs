using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Models
{
    public class AboutYou
    {
        public Guid Id { get; set; }
        public string CompanyInfo { get; set; }
        public string ActivityProfile { get; set; }
        public string CompanyGoals { get; set; }
    }
}
