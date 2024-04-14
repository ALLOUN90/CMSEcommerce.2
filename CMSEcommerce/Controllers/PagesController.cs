using CMSEcommerce.infrastrectur;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CMSEcommerce.Controllers
{
    public class PagesController (datacontext context) : Controller
    {
        private readonly datacontext _context= context;
        public  async Task< IActionResult> Index(string slug = "")
        {
            slug= slug.IsNullOrEmpty()? "home" : slug;
            Page Page = await _context.Pages.Where(x=>x.Slug==slug).FirstOrDefaultAsync();
            if(Page == null) { return NotFound(); }
            return View(Page);
        }
    }
}
