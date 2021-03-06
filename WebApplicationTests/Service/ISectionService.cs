using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
    public interface ISectionService
    {
        public IEnumerable<Section> Get();
        public Task<Section> Get(Guid sectionId);
        public Task Create(Section section);
    }

    public class SectionService : ISectionService
    {
        private readonly AppDb _db;

        public SectionService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<Section> Get()
        {
            return _db.Sections.Include(s => s.Test);
        }

        public async Task<Section> Get(Guid sectionId)
        {
            return await _db.Sections.FirstOrDefaultAsync(o => o.Id == sectionId);
        }

        public async Task Create(Section section)
        {
            await _db.Sections.AddAsync(section);
            await _db.SaveChangesAsync();
        }
    }
}
