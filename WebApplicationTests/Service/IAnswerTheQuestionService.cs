using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
    public interface IAnswerTheQuestionService
    {
        public IEnumerable<AnswerTheQuestion> Get();
        public Task Create(AnswerTheQuestion answer);
    }

    public class AnswerService : IAnswerTheQuestionService
    {
        private readonly AppDb _db;

        public AnswerService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<AnswerTheQuestion> Get()
        {
            return _db.Answers.Include(o => o.Question);
        }
        public async Task<AnswerTheQuestion> Get(Guid answerId)
        {
            return await _db.Answers.Include(o => o.Question).FirstOrDefaultAsync(o => o.Id == answerId);
        }
        public async Task Create(AnswerTheQuestion answer)
        {
            await _db.Answers.AddAsync(answer);
            await _db.SaveChangesAsync();

        }
    }
}
