using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTests.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answer;

        public AnswerController(IAnswerService answer)
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
        public async Task<IActionResult> Create(Answer answer)
        {
            await _answer.Create(answer);
            return RedirectToAction("Index");
        }
    }
}
