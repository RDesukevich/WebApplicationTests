using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTests.Models;
using WebApplicationTests.Service;

namespace WebApplicationTests.Controllers
{
    public class AnswerTheQuestionController : Controller
    {
        private readonly IAnswerTheQuestionService _answer;

        public AnswerTheQuestionController(IAnswerTheQuestionService answer)
        {
            _answer = answer;
        }

        public IActionResult Index()
        {
            return View(_answer.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnswerTheQuestion answer)
        {
            await _answer.Create(answer);
            return RedirectToAction("Index");
        }
    }
}
