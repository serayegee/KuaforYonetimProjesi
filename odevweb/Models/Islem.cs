using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{

    public class Islem
    {
        public int IslemId { get; set; }
        public string Ad { get; set; }
        public int Sure { get; set; }
        public double Ucret { get; set; }

        //[ForeignKey(nameof(Personel))]
        //public int PersonelId { get; set; }
        //public Personel Personel { get; set; }
        public ICollection<RandevuIslem> Randevus { get; set; }

        public ICollection<Personel> Personels { get; set; }
    }


}
