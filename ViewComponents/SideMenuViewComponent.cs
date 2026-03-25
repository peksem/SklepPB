using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SklepPB.DAL;

namespace SklepPB.ViewComponents
{
    public class SideMenuViewComponent : ViewComponent
    {
        FilmsContext db;

        public SideMenuViewComponent(FilmsContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var category = db.Categories.Include(c => c.Films).Where(c => c.Id == categoryId).Single();
            var categoryFilms = category.Films.ToList();

            return await Task.FromResult(View("_SideMenu", categoryFilms));
        }
    }
}
