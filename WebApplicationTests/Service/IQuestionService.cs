using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
    public interface IQuestionService
    {
        public IEnumerable<Question> Get();
        public Task<Question> Get(Guid questionId);
        public Task Create(Question question);
    }

    public class QuestionService : IQuestionService
    {
        private readonly AppDb _db;

        public QuestionService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<Question> Get()
        {
            return _db.Questions;
        }

        public async Task<Question> Get(Guid questionId)
        {
            return await _db.Questions.FirstOrDefaultAsync(o => o.Id == questionId);
        }

        public async Task Create(Question question)
        {
            await _db.Questions.AddAsync(question);
            await _db.SaveChangesAsync();
        }
    }
}
