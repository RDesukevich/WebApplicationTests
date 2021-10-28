using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
    public interface ITestService
    {
        public IEnumerable<Test> Get();
        public Test Get(Guid testId);
        public Task Create(Test test);
    }

    public class TestService : ITestService
    {
        private readonly AppDb _db;

        public TestService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<Test> Get()
        {
            return _db.Tests.Include(o => o.Section);
        }

        public Test Get(Guid testId)
        {
            return _db.Tests.Include(o => o.Section).FirstOrDefault(o => o.Id == testId);
        }

        public async Task Create(Test test)
        {
            await _db.Tests.AddAsync(test);
            await _db.SaveChangesAsync();
        }
    }
}
