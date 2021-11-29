using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid AnswerId { get; set; }
        public List<AnswerTheQuestion> Answers { get; set; } = new List<AnswerTheQuestion>();
    }
}
