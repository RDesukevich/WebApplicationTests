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
    public class QuestionController : Controller
    {
        private readonly IQuestionService _question;
        private readonly ITestService _test;

        public QuestionController(IQuestionService question, ITestService test)
        {
            _question = question;
            _test = test;
        }

        public IActionResult Index(Guid testId)
        {
            ViewBag.TestId = new SelectList(_question.Get(), "Id", "Name");
            return View(_question.GetForTest(testId));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            await _question.Create(question);
            return RedirectToAction("Index");
        }
    }
}
