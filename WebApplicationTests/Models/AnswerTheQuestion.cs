using System;

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
