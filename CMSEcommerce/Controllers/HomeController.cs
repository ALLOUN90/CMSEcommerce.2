using CMSEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CMSEcommerce.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
