using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SklepPB.Infrastructure;
using SklepPB.Models.Users;
using SklepPB.Models.ViewModels;

namespace SklepPB.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> Usermanager { get; }
        SignInManager<AppUser> Signinmanager { get; }

        public AccountController(UserManager<AppUser> usermanager, SignInManager<AppUser> signinmanager)
        {
            Usermanager = usermanager;
            Signinmanager = signinmanager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var user = await Usermanager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    user = new AppUser
                    {
                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        Email = model.Email
                    };

                    var result = await Usermanager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        ViewBag.Message = "Użytkownik utworzony";

                        await Signinmanager.SignInAsync(user, true);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var errors = string.Join("\n", result.Errors.ToList().Select(e => e.Description));

                        ViewBag.message = "Wystąpiły błędy:\n" + errors;
                    }

                }
                else
                {
                    ViewBag.Message = "Taki użytkownik już istnieje";
                }
            }
            catch (Exception e)
            {
                ViewBag.message = "błędy: \n" + e.Message;
            }
                return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Zapisz koszyk przed zalogowaniem (sesja zostanie zresetowana)
            var cartBackup = CartManager.GetItems(HttpContext.Session);

            var result = await Signinmanager.PasswordSignInAsync(model.UserName, model.Password, true, false);

            if (result.Succeeded)
            {
                // Przywróć koszyk po zalogowaniu
                SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, cartBackup);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Wystąpiły błędy: " + result.ToString();
            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            // Zapisz koszyk przed wylogowaniem
            var cartBackup = CartManager.GetItems(HttpContext.Session);

            await Signinmanager.SignOutAsync();

            // Przywróć koszyk po wylogowaniu
            SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, cartBackup);

            return RedirectToAction("Index", "Home");
        }
    }
}
