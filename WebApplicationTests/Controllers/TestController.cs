using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTests.Models;
using WebApplicationTests.Service;

namespace WebApplicationTests.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _test;

        public TestController(ITestService test)
        {
            _test = test;
        }

        public IActionResult Index()
        {
            return View(_test.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Test test)
        {
            await _test.Create(test);
            return RedirectToAction("Index");
        }
    }
}
