using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTests.Services;

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
