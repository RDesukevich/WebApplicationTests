using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTests.Models;
using WebApplicationTests.Service;

namespace WebApplicationTests.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService _section;

        public SectionController(ISectionService section)
        {
            _section = section;
        }

        public IActionResult Index()
        {
            return View(_section.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Section section)
        {
            await _section.Create(section);
            return RedirectToAction("Index");
        }
    }
}
