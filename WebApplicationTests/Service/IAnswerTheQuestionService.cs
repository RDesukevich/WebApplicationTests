using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
    public interface IAnswerTheQuestionService
    {
        public IEnumerable<AnswerTheQuestion> Get();
        public Task Create(AnswerTheQuestion answer);
    }

    public class AnswerTheQuestionService : IAnswerTheQuestionService
    {
        private readonly AppDb _db;

        public AnswerTheQuestionService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<AnswerTheQuestion> Get()
        {
            return _db.AnswerTheQuestions;
        }

        public async Task Create(AnswerTheQuestion answer)
        {
            await _db.AnswerTheQuestions.AddAsync(answer);
            await _db.SaveChangesAsync();

        }
    }
}
