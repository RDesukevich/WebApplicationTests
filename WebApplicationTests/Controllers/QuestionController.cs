using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _question;

        public QuestionController(IQuestionService question)
        {
            _question = question;
        }

        public IActionResult Index()
        {
            return View(_question.Get());
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
