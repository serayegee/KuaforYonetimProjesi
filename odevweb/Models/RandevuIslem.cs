using System.Collections.Generic;

namespace odevweb.Models
{
    public class RandevuIslem
    {
        public int RandevuIslemId { get; set; }
        public int IslemId { get; set; }
        public int PersonelId { get; set; }
        public int RandevuId { get; set; }

        public Islem Islem { get; set; } = null!;
        public Personel Personel { get; set; } = null!;
        public Randevu Randevu { get; set; } = null!;

    }
}
