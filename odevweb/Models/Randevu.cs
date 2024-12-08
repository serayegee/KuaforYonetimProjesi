using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
        public double ToplamUcret { get; set; }

        [ForeignKey(nameof(Musteri))]
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; } = null!;
    }
}
