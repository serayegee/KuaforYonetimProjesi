using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{
    public class RandevuPersonel
    {
        public int RandevuPersonelId { get; set; }
        public int RandevuId { get; set; }
        public int PersonelId { get; set; }
        public Randevu Randevu { get; set; }
        public Personel Personel { get; set; }
    }
}
