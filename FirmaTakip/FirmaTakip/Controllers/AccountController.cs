namespace FirmaTakip.Controllers
{
    using FirmaTakip.Entities;
    using FirmaTakip.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AccountController : Controller
        {
            private readonly SignInManager<AppUser> _signInManager;

            public AccountController(SignInManager<AppUser> signInManager)
            {
                _signInManager = signInManager;
            }
            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Login()
            {
                return View(new UserLoginModel());
            }
            [HttpPost]
            public IActionResult Login(UserLoginModel model)
            {
                if (ModelState.IsValid)
                {
                    var signInResult = _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false).Result;
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
                //return View(new KullaniciGirisModel());
                return View(model);
            }
            
            public IActionResult Logout()
            {
            //string key = "FirmaTakip";
            //string value = "";
            Response.Cookies.Delete("FirmaTakip");
            return RedirectToAction("index","home");
            }

        }
    

}