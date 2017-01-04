using SportStore.WebUI.Infrastructure;
using SportStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider provider;

        public AccountController(IAuthProvider param)
        {
            provider = param;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (provider.Authenticate(model.UserName, model.Password))
                {
                    return RedirectToAction(/*returnUrl ??*/Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub niepoprawne hasło");
                    return View();
                }
            }
            else return View();
        }
    }
}