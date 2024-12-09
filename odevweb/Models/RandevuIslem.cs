using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{
    public class RandevuIslem
    {
        //[ForeignKey(nameof(Islem))]
        public int IslemId { get; set; }
        //[ForeignKey(nameof(Randevu))]
        public int RandevuId { get; set; }
        public Islem Islem { get; set; }
        public Randevu Randevu { get; set; }

    }
}
