using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationTests.Models;
using WebApplicationTests.Service;

namespace WebApplicationTests.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _test;
        private readonly ISectionService _section;

        public TestController(ITestService test, ISectionService section)
        {
            _test = test;
            _section = section;
        }

        public IActionResult Index(Guid testId)
        {
            ViewBag.SectionId = new SelectList(_section.Get(), "Id", "Name");
            return View(_test.Get(testId));
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
