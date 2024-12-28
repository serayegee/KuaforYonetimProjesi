using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using odevweb.Models;

namespace odevweb.Controllers
{
    public class RandevuController : Controller
    {

        private readonly KuaforContext _context;

        public RandevuController(KuaforContext context)
        {
            _context = context;
            Console.WriteLine("RandevuController başarıyla başlatıldı.");

        }

        public IActionResult RandevuAl()
        {
           // ViewBag.Personeller = _context.Personels.Include(p => p.Islem).ToList();
            //ViewBag.Islemler = _context.Islems.ToList();
            return View();
        }

        /*KuaforContext _context = new KuaforContext();

        public RandevuController(KuaforContext context)
        {
            _context = context;
        }*/
        /*
        private readonly KuaforContext _context;

        // Dependency Injection ile Context alınıyor
        public RandevuController(KuaforContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RandevuAl()
        {
            ViewBag.Personeller = _context.Personels.Include(p => p.Islem).ToList();
            ViewBag.Islemler = _context.Islems.ToList();
            return View();
        }

        // GET: Randevu
        public async Task<IActionResult> RandevuIndex()
        {
            var randevular = await _context.Randevus.Include(r => r.Islems).Include(r => r.Personels).ToListAsync();
            return View(randevular);
        }

        [HttpPost]
        public IActionResult RandevuAl(Randevu randevu, int[] secilenIslemler, int[] secilenPersoneller)
        {
            if (ModelState.IsValid)
            {
                // İşlemleri ekle
                randevu.Islems = secilenIslemler.Select(islemId => new RandevuIslem
                {
                    IslemId = islemId
                }).ToList();

                // Personelleri ekle
                randevu.Personels = secilenPersoneller.Select(personelId => new RandevuPersonel
                {
                    PersonelId = personelId
                }).ToList();

                // Veritabanına kaydet
                _context.Randevus.Add(randevu);
                _context.SaveChanges();

                TempData["Success"] = "Randevunuz başarıyla oluşturuldu!";
                return RedirectToAction("RandevuAl");
            }

            // Model doğrulama hatası durumunda sayfayı tekrar yükle
            ViewBag.Personeller = _context.Personels.Include(p => p.Islem).ToList();
            ViewBag.Islemler = _context.Islems.ToList();
            return View(randevu);
        }

        // GET: Randevu/Create
        public IActionResult RandevuCreate()
        {
            return View();
        }

        // POST: Randevu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RandevuCreate(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        // GET: Randevu/Delete/5
        public async Task<IActionResult> RandevuDelete(int id)
        {
            var randevu = await _context.Randevus
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Randevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RandevuDeleteConfirmed(int id)
        {
            var randevu = await _context.Randevus.FindAsync(id);
            _context.Randevus.Remove(randevu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/
    }
}
