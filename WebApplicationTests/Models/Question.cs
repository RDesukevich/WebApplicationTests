using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public List<AnswerTheQuestion> Questions = new List<AnswerTheQuestion>();
    }
}
