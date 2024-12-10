using Microsoft.AspNetCore.Mvc;
using odevweb.Models;

namespace odevweb.Controllers
{
    public class AccountController : Controller
    {
       //private readonly KuaforContext _context;
        KuaforContext _context = new KuaforContext();
        /*public AccountController(KuaforContext context)
        {
            _context = context;
        }*/
       /* public IActionResult Index()
        {
            return View();
        }*/

        // GET: Login
        //[HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Kullanicis
                .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);

            if (kullanici != null)
            {
                if (kullanici.IsAdmin)
                {
                    return RedirectToAction("AdminPanel", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Kullanıcı adı veya şifre yanlış.";
            return View();
        }
    }

    
}
