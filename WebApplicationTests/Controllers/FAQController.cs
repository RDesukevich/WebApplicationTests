using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApplicationTests.Models;
using WebApplicationTests.Service;

namespace WebApplicationTests.Controllers
{
    public class FAQController : Controller
    {
        private readonly IFAQService _faq;

        public FAQController(IFAQService faqService)
        {
            _faq = faqService;
        }

        public IActionResult Index()
        {
            return View(_faq.Get());
        }
    }
}
