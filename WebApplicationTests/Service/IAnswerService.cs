using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Service
{
    public interface IAnswerService
    {
        public IEnumerable<Answer> Get();
        public Task Create(Answer answer);
    }

    public class AnswerService : IAnswerService
    {
        private readonly AppDb _db;

        public AnswerService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<Answer> Get()
        {
            return _db.Answers;
        }

        public async Task Create(Answer answer)
        {
            await _db.Answers.AddAsync(answer);
            await _db.SaveChangesAsync();

        }
    }
}
