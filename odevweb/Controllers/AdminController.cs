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
                        kullanici.Soyad = model.Soyad;
                        kullanici.Telefon = model.Telefon;

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
            var KuaforContext = _context.Personels.Include(k => k.Islem);
            return View(await KuaforContext.ToListAsync());
        }

        public async Task<IActionResult> PersonelDetails(int? id)
        {
            if(id == null || _context.Personels==null)
            {
                return NotFound();
            }

            var personel = await _context.Personels
                .Include(k => k.Islem)
                .FirstOrDefaultAsync(m=>m.PersonelId == id);

            if(personel==null)
            {
                return NotFound();
            }

            return View(personel);
        }

        [HttpGet]
        public IActionResult PersonelCreate()
        {
            ViewData["IslemId"] = new SelectList(_context.Islems, "IslemId", "IslemAd");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonelCreate([Bind("PersonelId,PersonelAd,PersonelSoyad, IslemId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personel);
                await _context.SaveChangesAsync();
                return RedirectToAction("PersonelIndex");
            }
            if (!ModelState.IsValid)
            {
                foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(modelError.ErrorMessage);
                }
               
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
        public async Task<IActionResult> PersonelEdit(int id, [Bind("PersonelId,PersonelAd, PersonelSoyad, IslemId")] Personel personel)
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
     
        public IActionResult IslemIndex()
        {
            var islemler = _context.Islems.ToList();
            return View(islemler);
        
        }

        public IActionResult IslemCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IslemKaydet(Islem i) 
        {
            if(ModelState.IsValid)
            {
                _context.Islems.Add(i);
                _context.SaveChanges();
                return RedirectToAction("IslemIndex");
            }
            return RedirectToAction("IslemCreate");
        }

        [HttpGet]
        public IActionResult IslemEdit(int id)
        {
            var islem = _context.Islems.FirstOrDefault(i => i.IslemId == id);
            if (islem == null)
            {
                return NotFound();
            }
            return View(islem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IslemEdit(Islem islem)
        {
            if (ModelState.IsValid)
            {
                var existingIslem = _context.Islems.FirstOrDefault(i => i.IslemId == islem.IslemId);
                if (existingIslem != null)
                {
                    existingIslem.IslemAd = islem.IslemAd;
                    existingIslem.Sure = islem.Sure;
                    existingIslem.Ucret = islem.Ucret;

                    _context.SaveChanges();
                    return RedirectToAction("IslemIndex");
                }
            }
            return View(islem);
        }

        [HttpGet]
        public IActionResult IslemDetails(int id)
        {
            var islem = _context.Islems.FirstOrDefault(i => i.IslemId == id);
            if (islem == null)
            {
                return NotFound();
            }
            return View(islem);
        }


        [HttpGet]
        public IActionResult IslemDelete(int? id)
        {
            // İşlem verisini almak için veritabanına bağlanıyoruz
            var islem = _context.Islems.FirstOrDefault(i => i.IslemId == id);
            if (islem == null)
            {
                return NotFound(); // İşlem bulunamazsa 404 döndür
            }
            return View(islem); // İşlem verisiyle silme sayfasını göster
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IslemDeleteConfirmed(int id)
        {
            Console.WriteLine($"Silinmek istenen IslemId: {id}");

            var islem = _context.Islems.FirstOrDefault(i => i.IslemId == id);
            if (islem == null)
            {
                Console.WriteLine("İşlem bulunamadı!");
                return RedirectToAction("IslemIndex");
            }

            _context.Islems.Remove(islem);
            _context.SaveChanges();

            Console.WriteLine("İşlem başarıyla silindi!");
            return RedirectToAction("IslemIndex");
        }

        public IActionResult RandevuListesi()
        {
            var randevular = _context.Randevus
                .Include(r => r.Kullanici)
                .Include(r => r.Personel)
                .Include(r => r.Islem)
                .ToList();
            return View(randevular);
        }

        [HttpGet]
        public IActionResult RandevuEkle()
        {
            ViewData["MusteriId"] = new SelectList(_context.Kullanicis, "KullaniciId", "Ad");
            ViewData["PersonelId"] = new SelectList(_context.Personels, "PersonelId", "PersonelAd");
            ViewData["IslemId"] = new SelectList(_context.Islems, "IslemId", "IslemAd");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RandevuEkle(Randevu model)
        {
            if (ModelState.IsValid)
            {
                _context.Randevus.Add(model);
                _context.SaveChanges();
                return RedirectToAction("RandevuListesi");
            }
            ViewData["KullaniciId"] = new SelectList(_context.Musteris, "KullaniciId", "Ad", model.KullaniciId);
            ViewData["PersonelId"] = new SelectList(_context.Personels, "PersonelId", "PersonelAd", model.PersonelId);
            ViewData["IslemId"] = new SelectList(_context.Islems, "IslemId", "IslemAd", model.IslemId);
            return View(model);
        }



    }
}
