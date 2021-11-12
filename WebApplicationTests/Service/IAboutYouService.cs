using System.Collections.Generic;
using WebApplicationTests.Data;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
    public interface IAboutYouService
    {
        public IEnumerable<AboutYou> Get();
    }

    public class AboutYouService : IAboutYouService
    {
        private readonly AppDb _db;

        public AboutYouService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<AboutYou> Get()
        {
            return _db.AboutYous;
        }
    }
}
