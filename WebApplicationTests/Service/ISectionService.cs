using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Service
{
    public interface ISectionService
    {
        public IEnumerable<BitVector32.Section> Get();
        public Task<BitVector32.Section> Get(Guid sectionId);
        public Task Create(BitVector32.Section section);
    }

    public class SectionService : ISectionService
    {
        private readonly AppDb _db;

        public SectionService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<BitVector32.Section> Get()
        {
            return _db.Sections;
        }

        public async Task<BitVector32.Section> Get(Guid sectionId)
        {
            return await _db.Sections.FirstOrDefaultAsync(o => o.Id == sectionId);
        }

        public async Task Create(BitVector32.Section section)
        {
            await _db.Sections.AddAsync(section);
            await _db.SaveChangesAsync();
        }
    }
}
