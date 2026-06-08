using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SklepPB.DAL;
using SklepPB.Models.ViewModels;

namespace SklepPB.Controllers
{
    public class FilmsController : Controller
    {

        FilmsContext db;
        IWebHostEnvironment hostEnvironment;

        public FilmsController(FilmsContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllFilms()
        {
            var films = db.Films.ToList();
            return View(films);
        }

        public IActionResult CategoryFilms(string categoryName)
        {
            var category = db.Categories.Include(c => c.Films).Where(c => c.Name.ToUpper() == categoryName.ToUpper()).Single();

            var films = category.Films.ToList();

            return View(films);
        }

        public IActionResult Details(int filmId)
        {
            var film = db.Films.Find(filmId);
            var category = db.Categories.Find(film.CategoryId);

            return View(film);
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            var model = new AddFilmViewModel();
            
            model.Categories = db.Categories.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddFilm(AddFilmViewModel model)
        {
            var picFolder = Path.Combine(hostEnvironment.WebRootPath, "content", "grafiki");

            if (model.Poster != null && model.Poster.Length > 0)
            {
                var posterName = Guid.NewGuid() + "_" + model.Poster.FileName;
                var filePath = Path.Combine(picFolder, posterName);
                model.Poster.CopyTo(new FileStream(filePath, FileMode.Create));
                model.Film.Poster = posterName;
            }

            db.Films.Add(model.Film);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Search(string text)
        {
            var films = from f in db.Films select f;
            if(!String.IsNullOrEmpty(text))
            {
                films = films.Where(f => f.Title.ToLower().Contains(text.ToLower()));

                return View("CategoryFilms", films.ToList());
            }

            return RedirectToAction("Index");
        }
    }
}

