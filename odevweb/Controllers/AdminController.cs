using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using odevweb.Models;

namespace odevweb.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminPanel() 
        {
            return View();
        }

        public IActionResult KullaniciListesi() 
        { 
            using (var context = new KuaforContext())
            {
                var kullanicilar = context.Kullanicis.ToList();
                return View(kullanicilar);
            }
        }

        [HttpGet]
        public IActionResult KullaniciEkle()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult KullaniciEkle(Kullanici model)
        {
            if(ModelState.IsValid)
            {
                using (var context = new KuaforContext()) 
                { 
                    context.Kullanicis.Add(model);
                    context.SaveChanges();
                }
                return RedirectToAction("KullaniciListesi");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult KullaniciDuzenle(int id)
        {
            using(var context = new KuaforContext()) 
            {
                var kullanici = context.Kullanicis.FirstOrDefault(k => k.KullaniciId == id);
                if(kullanici == null) { return NotFound(); }
                return View(kullanici);

            }
        }

        [HttpPost]
        public IActionResult KullaniciDuzenle(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new KuaforContext())
                {
                    var kullanici = context.Kullanicis.FirstOrDefault(k => k.KullaniciId == model.KullaniciId);
                    if (kullanici != null)
                    {
                        kullanici.Ad = model.Ad;
                        kullanici.KullaniciAdi = model.KullaniciAdi;
                        kullanici.Sifre = model.Sifre; // Şifreyi hashlemek gerekebilir
                        kullanici.IsAdmin = model.IsAdmin;

                        context.SaveChanges();
                        return RedirectToAction("KullaniciListesi");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult KullaniciSil(int id)
        {
            using (var context = new KuaforContext())
            {
                var kullanici = context.Kullanicis.FirstOrDefault(k => k.KullaniciId == id);
                if (kullanici == null)
                {
                    return NotFound(); // Kullanıcı bulunamazsa 404 döndür
                }
                return View(kullanici); // Silmeden önce kullanıcıyı göster
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KullaniciSilConfirmed(int id)
        {
            if (id == 0) // id'nin 0 veya null olup olmadığını kontrol edin
            {
                return NotFound("Geçersiz Kullanıcı ID");
            }

            using (var context = new KuaforContext())
            {
                var kullanici = context.Kullanicis.FirstOrDefault(k => k.KullaniciId == id);
                if (kullanici != null)
                {
                    context.Kullanicis.Remove(kullanici);
                    context.SaveChanges();
                }

                return RedirectToAction("KullaniciListesi");
            }
        }
        
        [HttpGet]
        public IActionResult PersonelEkle()
        {

            using (var context = new KuaforContext())
            {
                var model = new PersonelEkleViewModel
                {
                    Personel = new Personel(),
                    Islemler = context.Islems.ToList() // Dropdown için işlemleri al
                };
                return View(model);
            }
            /* using (var context = new KuaforContext())
             {
                 // İşlem listesini dropdown için ViewBag ile gönderiyoruz
                 ViewBag.Islemler = context.Islems.ToList();
                 return View();
             }*/

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelEkle(PersonelEkleViewModel model)
        {
            if (model.Personel.IslemId == 0) // İşlem seçilmemişse
            {
                ModelState.AddModelError("Personel.IslemId", "Lütfen bir işlem seçin.");
            }

            if (ModelState.IsValid)
            {
                using (var context = new KuaforContext())
                {
                    context.Personels.Add(model.Personel);
                    context.SaveChanges();
                    return RedirectToAction("PersonelListesi");
                }
            }

            // Hata durumunda dropdown'u tekrar doldur
            using (var context = new KuaforContext())
            {
                model.Islemler = context.Islems.ToList();
            }
            return View(model);
        }


        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelEkle(Personel model)
        {
            Console.WriteLine($"Ad: {model.Ad}, Soyad: {model.Soyad}, IslemId: {model.IslemId}");

            if (model.IslemId == 0)
            {
                ModelState.AddModelError("IslemId", "Lütfen bir işlem seçin.");
            }

            if (ModelState.IsValid)
            {
                using (var context = new KuaforContext())
                {
                    context.Personels.Add(model);
                    context.SaveChanges();
                    Console.WriteLine("Personel başarıyla kaydedildi.");
                    return RedirectToAction("PersonelListesi");
                }
            }

            Console.WriteLine("ModelState geçerli değil.");
            using (var context = new KuaforContext())
            {
                ViewBag.Islemler = context.Islems.ToList();
            }

            return View(model);
        }*/


        public IActionResult IslemListesi()
        {
            using (var context = new KuaforContext())
            {
                var islemler = context.Islems.ToList(); // Veritabanından işlemleri çek
                return View(islemler); // Görünümü işlemlerle birlikte döndür
            }
        }

        public IActionResult PersonelListesi()
        {
            using (var context = new KuaforContext())
            {
                var personeller = context.Personels.ToList(); // Veritabanından işlemleri çek
                return View(personeller); // Görünümü işlemlerle birlikte döndür
            }
        }

    }
}
