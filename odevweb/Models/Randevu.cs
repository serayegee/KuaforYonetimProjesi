using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
        //public double ToplamUcret { get; set; }

        [ForeignKey(nameof(Kullanici))]
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        //public Musteri Musteri { get; set; } = null!;
        //public ICollection<RandevuIslem>? Islems { get; set; }
        //public ICollection<RandevuPersonel>? Personels { get; set; }

        // Her randevu bir işlemle ilişkilidir
        public int IslemId { get; set; }
        public Islem? Islem { get; set; }

        // Personel ilişkisi
        public int PersonelId { get; set; }
        public Personel? Personel { get; set; }
    }
}
