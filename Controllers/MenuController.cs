using Microsoft.AspNetCore.Mvc;
using BakingG.Views.Menu;

namespace BakingG.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pancake()
        {
            return View();
        }

        public IActionResult Cookies()
        {
            return View();
        }

        public IActionResult ApplePie()
        {
            return View();
        }

        public IActionResult Oven()
        {
            return View();
        }
        public IActionResult Loading()
        {
            return View();
        }
        public IActionResult Inbox()
        {
            return View();
        }

    }
}
