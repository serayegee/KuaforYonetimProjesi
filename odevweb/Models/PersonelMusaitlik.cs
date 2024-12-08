using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{
    public class PersonelMusaitlik
    {
        public int PersonelMusaitlikId { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public DateTime Tarih { get; set; }
        [ForeignKey(nameof(Personel))]
        public int PersonelId { get; set; }

        public Personel Personel { get; set; } = null!;
    }
}
