using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Models
{
    public class AnswerTheQuestion
    {
        public Guid Id { get; set; }
        public string AnswerToTheQuestion { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
