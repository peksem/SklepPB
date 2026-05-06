using Microsoft.AspNetCore.Mvc;
using SklepPB.DAL;
using SklepPB.Infrastructure;

namespace SklepPB.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        FilmsContext db;

        public MenuViewComponent(FilmsContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.CartQuantity = CartManager.GetCartQuantity(HttpContext.Session);

            return await Task.FromResult(View("_Menu", db.Categories.ToList()));
        }

    }
}
