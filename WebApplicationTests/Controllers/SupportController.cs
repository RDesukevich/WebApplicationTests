using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTests.Models;
using WebApplicationTests.Service;
using WebApplicationTests.Services;

namespace WebApplicationTests.Controllers
{
    public class SupportController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISupportService _supportService;

        public SupportController(IUserService userService, ISupportService supportService)
        {
            _userService = userService;
            _supportService = supportService;
        }

        public async Task<IActionResult> CreateTicket()
        {
            var ticket = new SupportTicket();
            if (!HttpContext.User.Identity!.IsAuthenticated) return View(ticket);
            var user = await _userService.GetUserAsync(HttpContext.User.Identity.Name);
            ticket.UserName = user.Login;
            ticket.UserEmailAddress = user.Email;

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(SupportTicket supportTicket)
        {
            await _supportService.CreateSupportTicket(supportTicket);
            return RedirectToAction("Index", "Home");
        }
    }
}