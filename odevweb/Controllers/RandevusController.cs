using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using odevweb.Models;

namespace odevweb.Controllers
{
    public class RandevusController : Controller
    {
        KuaforContext _context = new KuaforContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RandevusAl(Randevu randevu, int islemId, int personelId)
        {
            if (ModelState.IsValid)
            {
                randevu.IslemId = islemId; // Seçilen işlem
                randevu.PersonelId = personelId; // Seçilen personel

                // Veritabanına kaydet
                _context.Randevus.Add(randevu);
                _context.SaveChanges();

                TempData["Success"] = "Randevunuz başarıyla oluşturuldu!";
                return RedirectToAction("RandevusAl");
            }

            // Hatalı durumda sayfayı tekrar yükle
            ViewBag.Personeller = _context.Personels.ToList();
            ViewBag.Islemler = _context.Islems.ToList();
            return View(randevu);
        }


        [HttpGet]
		public IActionResult FiltrePersoneller(int islemId)
		{
            // Seçilen işleme göre personelleri filtrele
            var personeller = _context.Personels
                .Where(p => p.IslemId == islemId)
                .ToList();

            // Personellerin sadece gerekli alanlarını JSON olarak döndür
            var filteredPersonellers = personeller.Select(p => new
            {
                personelId = p.PersonelId,
                personelAd = p.PersonelAd,
                personelSoyad = p.PersonelSoyad
            }).ToList();

            return Json(filteredPersonellers); // JSON formatında döndür
        }
	}
}
