using Microsoft.AspNetCore.Mvc;
using WebApplicationTests.Service;

namespace WebApplicationTests.Controllers
{
    public class AboutYouController : Controller
    {
        private readonly IAboutYouService _aboutYouService;

        public AboutYouController(IAboutYouService aboutYouService)
        {
            _aboutYouService = aboutYouService;
        }

        public IActionResult Index()
        {
            return View(_aboutYouService.Get());
        }
    }
}
