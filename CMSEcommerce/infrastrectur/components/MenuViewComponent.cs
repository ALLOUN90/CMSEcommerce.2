using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSEcommerce.infrastrectur.components
{
    public class MenuViewComponent(datacontext context) : ViewComponent
    {
        private readonly datacontext _context = context;
        

        public async Task<IViewComponentResult> InvokeAsync() {
             return View(await _context.Pages.Where(x=>x.Slug != "home").ToListAsync());
        } 
    }
}
