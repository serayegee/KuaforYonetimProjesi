using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using odevweb.Models;
using System.Data;
using System.Security.Claims;

namespace odevweb.Controllers
{
    public class AccountController : Controller
    {
        KuaforContext _context = new KuaforContext();

         public IActionResult Index()
         {
             return View();
         }
        
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string kullaniciAdi, string sifre)
        {
            // Kullanıcıyı veritabanında kontrol et
            var kullanici = _context.Kullanicis
                .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);

            if (kullanici != null)
            {
                // Kullanıcı bilgilerini içeren Claim listesi oluştur
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, kullanici.Ad), // Kullanıcının adı
            new Claim(ClaimTypes.Email, kullanici.KullaniciAdi), // Kullanıcı adı (e-posta)
            new Claim(ClaimTypes.Role, kullanici.IsAdmin ? "Admin" : "User") // Rol bilgisi
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Kullanıcıyı oturum açtır
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Admin kullanıcıysa admin paneline yönlendir
                if (kullanici.IsAdmin)
                {
                    return RedirectToAction("AdminPanel", "Admin");
                }

                // Normal kullanıcıysa ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }

            // Hatalı girişte hata mesajı
            ViewBag.Error = "Kullanıcı adı veya şifre yanlış.";
            return View();
        }


        public IActionResult Register() 
        {
            return View();
        }

        // Üye Ol İşlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcıyı veritabanına kaydet
                var yeniKullanici = new Kullanici
                {
                    KullaniciAdi = model.KullaniciAdi,
                    Sifre = model.Sifre, 
                    IsAdmin = false, // Yeni kullanıcılar admin değil
                    Ad = model.Ad, 
                    Soyad = model.Soyad,
                    Telefon = model.Telefon
                };

                _context.Kullanicis.Add(yeniKullanici);
                _context.SaveChanges();

                // Kullanıcı bilgileriyle oturum aç
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Ad),
                    new Claim(ClaimTypes.Email, model.KullaniciAdi),
                    new Claim(ClaimTypes.Role, "User")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Başarılı olursa ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}

    

