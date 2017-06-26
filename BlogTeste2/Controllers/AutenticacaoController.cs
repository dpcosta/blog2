using BlogTeste2.Infra;
using BlogTeste2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BlogTeste2.Controllers
{
    public class AutenticacaoController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioManager manager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();
                Usuario usuario = manager.Find(model.LoginName, model.Password);
                if (usuario != null)
                {
                    ClaimsIdentity identity = manager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties() { }, identity);
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                } else
                {
                    return View(model);
                }
            } else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        [ChildActionOnly]
        public ActionResult UsuarioLogado()
        {
            UsuarioManager manager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            return View(user);
        }
    }
}