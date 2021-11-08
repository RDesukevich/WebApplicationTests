using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
    public interface IQuestionService
    {
        public IEnumerable<Question> Get();
        public Task<Question> Get(Guid questionId);
        public Task Create(Question question);
        public IEnumerable<Question> GetForTest(Guid testId);
    }

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionService _question;
        private readonly AppDb _db;

        public QuestionService(IQuestionService question,AppDb db)
        {
            _question = question;
            _db = db;
        }

        public IEnumerable<Question> Get()
        {

            return _db.Questions.Include(o => o.Test);
        }

        public async Task<Question> Get(Guid questionId)
        {
            return await _db.Questions.Include(o => o.Test).FirstOrDefaultAsync(o => o.Id == questionId);
        }

        public async Task Create(Question question)
        {
            await _db.Questions.AddAsync(question);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Question> GetForTest(Guid testId)
        {
           return _db.Questions.Include(o => o.Answers).Where(q => q.TestId == testId);
        }

    }
}
