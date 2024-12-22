using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using odevweb.Models;
using System.Drawing;

namespace odevweb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        KuaforContext _context = new KuaforContext();


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
            if (ModelState.IsValid)
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
            using (var context = new KuaforContext())
            {
                var kullanici = context.Kullanicis.FirstOrDefault(k => k.KullaniciId == id);
                if (kullanici == null) { return NotFound(); }
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

        public async Task<IActionResult> PersonelIndex()
        {
            var KuaforContext = _context.Personels.Include(p => p.Islem);
            return View(await KuaforContext.ToListAsync());
        }

        public async Task<IActionResult> PersonelDetails(int? id)
        {
            if(id == null || _context.Personels==null)
            {
                return NotFound();
            }

            var personel = await _context.Personels
                .Include(p => p.Islem)
                .FirstOrDefaultAsync(m=>m.PersonelId == id);

            if(personel==null)
            {
                return NotFound();
            }

            return View(personel);
        }

        //[HttpGet]
        public IActionResult PersonelCreate()
        {
            /*
              using (var context = new KuaforContext())
              {
                  // İşlem listesini dropdown için SelectList olarak ViewBag'e gönderiyoruz
                  ViewBag.IslemId = new SelectList(context.Islems, "IslemId", "Ad");
                  return View();
              }*/
            /*
            using (var context = new KuaforContext())
            {
                var model = new Personel
                {
                    personel = new Personel(),
                    Islemler = context.Islems.ToList() // Dropdown için işlemleri al
                };
                return View(model);
            }*/
            /* using (var context = new KuaforContext())
             {
                // İşlem listesini dropdown için ViewBag ile gönderiyoruz
                ViewBag.Islemler = context.Islems.ToList();
                 return View();
             }*/

            /* using (var context = new KuaforContext())
             {
                 // İşlemleri SelectList'e çevirip ViewBag'e atıyoruz
                 ViewBag.IslemId = new SelectList(context.Islems, "IslemId", "Ad");
                 return View();
             }*/

            ViewData["IslemId"] = new SelectList(_context.Islems, "IslemId", "IslemAd");
            return View();

        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelEkle(Personel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new KuaforContext())
                {
                    // Girilen IslemId'nin veritabanında mevcut olup olmadığını kontrol edin
                    var islem = context.Islems.FirstOrDefault(i => i.IslemId == model.IslemId);
                    if (islem == null)
                    {
                        ModelState.AddModelError("IslemId", "Geçersiz İşlem ID. Lütfen doğru bir ID girin.");
                        return View(model);
                    }

                    // Personel kaydını ekle
                    context.Personels.Add(model);
                    context.SaveChanges();

                    return RedirectToAction("PersonelListesi");
                }
            }

            // Hata durumunda aynı sayfayı döndür
            return View(model);
        }
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonelCreate([Bind("PersonelId,PersonelAd,PersonelSoyad,Uzmanlik, IslemId")] Personel personel)
        {
            if(ModelState.IsValid)
            {
                _context.Add(personel);
                await _context.SaveChangesAsync();
                return RedirectToAction("PersonelIndex");
            }
            ViewData["IslemId"] = new SelectList(_context.Islems, "IslemId", "IslemAd", personel.IslemId);
            return View(personel);
        }

        public async Task<IActionResult> PersonelEdit(int? id)
        {
            if (id == null || _context.Personels == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels.FindAsync(id);
            if (personel == null) { return NotFound(); }

            ViewData["IslemId"] = new SelectList(_context.Islems, "IslemId", "IslemAd", personel.IslemId);
            return View(personel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonelEdit(int id, [Bind("PersonelId,PersonelAd,IslemId")] Personel personel)
        {
            if (id != personel.PersonelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelExists(personel.PersonelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(PersonelIndex));
            }
            ViewData["IslemId"] = new SelectList(_context.Islems, "IslemId", "IslemAd", personel.IslemId);
            return View(personel);
        }

        public async Task<IActionResult> PersonelDelete(int? id)
        {
            if (id == null || _context.Personels == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels
                .Include(k => k.Islem)
                .FirstOrDefaultAsync(m => m.PersonelId == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        [HttpPost, ActionName("PersonelDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonelDeleteConfirmed(int id)
        {
            if (_context.Personels == null)
            {
                return Problem("Entity set 'KuaforContext.Personels'  is null.");
            }
            var personel = await _context.Personels.FindAsync(id);
            if (personel != null)
            {
                _context.Personels.Remove(personel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("PersonelIndex");
        }

        private bool PersonelExists(int id)
        {
            return (_context.Personels?.Any(e => e.PersonelId == id)).GetValueOrDefault();
        }


        /*
        public IActionResult PersonelEkle(Personel model)
        {

            if (ModelState.IsValid)
            {
                using (var context = new KuaforContext())
                {
                    // İşlem ID'nin geçerli olup olmadığını kontrol et
                    var islem = context.Islems.FirstOrDefault(i => i.IslemId == model.IslemId);
                    if (islem == null)
                    {
                        ModelState.AddModelError("IslemId", "Geçersiz İşlem ID. Lütfen doğru bir işlem seçin.");
                        ViewBag.IslemId = new SelectList(context.Islems, "IslemId", "Ad");
                        return View(model);
                    }

                    // Personel kaydını ekle
                    context.Personels.Add(model);
                    context.SaveChanges();

                    return RedirectToAction("PersonelListesi");
                }
            }

            // Hata durumunda dropdown'u tekrar doldur
            using (var context = new KuaforContext())
            {
                ViewBag.IslemId = new SelectList(context.Islems, "IslemId", "Ad");
            }
            return View(model);
            /*

              if (ModelState.IsValid)
              {
                  using (var context = new KuaforContext())
                  {
                      context.Personels.Add(model);
                      context.SaveChanges();
                      return RedirectToAction("PersonelListesi");
                  }
              }

              // Hata durumunda dropdown'u doldur
              using (var context = new KuaforContext())
              {
                  ViewBag.Islemler = context.Islems.ToList();
              }
              return View(model);}*/



        public IActionResult IslemListesi()
        {
            using (var context = new KuaforContext())
            {
                var islemler = context.Islems.ToList(); // Veritabanından işlemleri çek
                return View(islemler); // Görünümü işlemlerle birlikte döndür
            }
        }


        /*
        public IActionResult PersonelListesi()
        {
            using (var context = new KuaforContext())
            {
                var personeller = context.Personels.ToList(); // Veritabanından işlemleri çek
                return View(personeller); // Görünümü işlemlerle birlikte döndür
            }
        }

        [HttpGet]
        public IActionResult PersonelSil(int id)
        {
            using (var context = new KuaforContext())
            {
                var personel = context.Personels.FirstOrDefault(p => p.PersonelId == id);
                if (personel == null)
                {
                    return NotFound(); // Eğer personel bulunamazsa 404 döndür
                }
                return View(personel); // Silmeden önce personeli göster
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelSilConfirmed(int id)
        {
            using (var context = new KuaforContext())
            {
                var personel = context.Personels.FirstOrDefault(p => p.PersonelId == id);
                if (personel != null)
                {
                    context.Personels.Remove(personel); // Personeli sil
                    context.SaveChanges(); // Değişiklikleri kaydet
                }
                return RedirectToAction("PersonelListesi"); // Listeye geri dön
            }
        }*/



    }
}
