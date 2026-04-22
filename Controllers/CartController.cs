using Microsoft.AspNetCore.Mvc;
using SklepPB.DAL;
using SklepPB.Infrastructure;

namespace SklepPB.Controllers
{
    public class CartController : Controller
    {
        FilmsContext db;

        public CartController(FilmsContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var cart = CartManager.GetItems(HttpContext.Session);
            ViewBag.Total = CartManager.GetCartTotalValue(HttpContext.Session);

            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            CartManager.AddToCart(HttpContext.Session, db, id);
            return RedirectToAction("Index");
        }
    }
}
