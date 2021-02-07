using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebASPIdentityWithZeroByOWIN.App_Start;
using WebASPIdentityWithZeroByOWIN.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

namespace WebASPIdentityWithZeroByOWIN.Controllers
{
    public class AccountController : Controller
    {
        ApplicationUserManager _userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        IAuthenticationManager _authManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                Age = model.Age
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View(model);
        }


        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindAsync(model.Email, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }

                var claim = await _userManager.CreateIdentityAsync(
                    user, DefaultAuthenticationTypes.ApplicationCookie);

                _authManager.SignOut();
                _authManager.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = true
                }, claim);

                if (string.IsNullOrWhiteSpace(returnUrl))
                    return RedirectToAction("Index", "Home");

                return Redirect(returnUrl);
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

    }
}