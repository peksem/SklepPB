using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SklepPB.DAL;
using SklepPB.Models;

namespace SklepPB.Controllers
{
    public class HomeController : Controller
    {

        FilmsContext db;

        public HomeController(FilmsContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var categories = db.Categories.ToList();
            var featuredFilms = db.Films.Where(f => f.Poster != null).OrderBy(f => Guid.NewGuid()).Take(6).ToList();
            ViewBag.FeaturedFilms = featuredFilms;

            return View(categories);
        }

        public IActionResult FooterSites(string name)
        {
            return View(name);
        }

    }
}
