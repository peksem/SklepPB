using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SklepPB.DAL;

namespace SklepPB.Controllers
{
    public class FilmsController : Controller
    {

        FilmsContext db;

        public FilmsController(FilmsContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryFilms(string categoryName)
        {
            var category = db.Categories.Include("Films").Where(c => c.Name.ToUpper() == categoryName.ToUpper()).Single();

            var films = category.Films.ToList();

            return View(films);
        }
    }
}
