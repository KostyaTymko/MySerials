using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using MySerials.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using System.Data;
using System.Data.Entity;

using System.Net;




namespace MySerials.Controllers
{

    public class AccountController : Controller
    {
        MainFunction a = new MainFunction();
        SerialContext db = new SerialContext();
        public ActionResult Index()
        {
             return View("~/Views/Home/Index.cshtml", "_AdminLayout",a.Index());
        }

        public ActionResult Catalog()
        {
            IEnumerable<Serial> serials = db.Serials;
            ViewBag.Serials = serials;
            return View("~/Views/Home/Catalog.cshtml", "_AdminLayout", ViewBag.Serials);
        }

        public ActionResult Search(string Search)
        {
            return View("~/Views/Account/Search.cshtml", "_AdminLayout", a.Search(Search));
        }

        public ActionResult MyArticles()
        {
            return View("~/Views/Home/MyArticles.cshtml","_AdminLayout");
        }

        public ActionResult MySerials()
        {
            return View("~/Views/Home/MySerials.cshtml", "_AdminLayout");
        }

        public ActionResult Schedule()
        {
            return View("~/Views/Home/Schedule.cshtml", "_AdminLayout");
        }

        public ActionResult Lists()
        {
            return View("~/Views/Home/Lists.cshtml", "_AdminLayout");
        }

        //-----------------------------------------------------------------------------------------------------------------
        private UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Year = DateTime.Now.Year
                };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
            //return View("Login", "_AdminLayout");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Wrong login or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(
                        new AuthenticationProperties()
                        {
                            IsPersistent = true
                        }
                     );
                    if (String.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        return RedirectToAction(returnUrl);
                    }
                }

            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}