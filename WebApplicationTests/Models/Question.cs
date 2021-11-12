﻿using System;
using System.Collections.Generic;

namespace WebApplicationTests.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid AnswerId { get; set; }
        public Guid UserAnswerId { get; set; }
        public List<AnswerTheQuestion> Answers { get; set; } = new List<AnswerTheQuestion>();
    }
}
