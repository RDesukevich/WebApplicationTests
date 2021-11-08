using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTests.Services;

namespace WebApplicationTests.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ISupportService _supportService;

        public AdminController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _supportService.GetAllTicketsAsync());
        }
    }
}