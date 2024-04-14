using CMSEcommerce.infrastrectur;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CMSEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController(datacontext context) : Controller
    {
        private readonly datacontext _context = context;
        public async Task<IActionResult> Index()
        {
            //slug= slug.IsNullOrEmpty()? "home" : slug;
            List<Page> Pages = await _context.Pages.ToListAsync();

            return View(Pages);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                var Slug = await _context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);

                if (Slug != null)
                {
                    ModelState.AddModelError("", "That page already exiseta!");
                    return View(page);
                }
                _context.Add(page);
                await _context.SaveChangesAsync();
                TempData["Success"] = "The page has been added!";
                return RedirectToAction("Index");
            }

            return View(page);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Page page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");
                var Slug = await _context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug && x.Id != page.Id);

                if (Slug != null)
                {
                    ModelState.AddModelError("", "That page already exiseta!");
                    return View(page);
                }
                _context.Update(page);
                await _context.SaveChangesAsync();
                TempData["Success"] = "The page has been edited!";
                return RedirectToAction("Index");
            }

            return View(page);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Page page = await _context.Pages.FindAsync(id);
            if (page == null || id==1)
            {
                TempData["Error"] = "The page does not exist!";
            }
            else
            {
                _context.Pages.Remove(page);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
