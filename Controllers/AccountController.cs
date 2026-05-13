using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SklepPB.Models.Users;

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

        public async Task<IActionResult> Register()
        {
            try
            {
                var user = await Usermanager.FindByNameAsync("TestUser2");

                if (user == null)
                {
                    user = new AppUser
                    {
                        UserName = "TestUser2",
                        FirstName = "Test",
                        LastName = "User",
                        Address = "Test Address",
                        Email = "testuser@gmail2.com"
                    };

                    await Usermanager.CreateAsync(user, "Test");
                    ViewBag.Message = "Użytkownik utworzony";

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
    }
}
