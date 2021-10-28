using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
    public interface IFAQService
    {
        public IEnumerable<FAQ> Get();
    }

    public class FAQService : IFAQService
    {
        private readonly AppDb _db;

        public FAQService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<FAQ> Get()
        {
            return _db.FAQS;
        }
    }
}
