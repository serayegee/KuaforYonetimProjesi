using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{
    public class Personel
    {
        public int PersonelId { get; set; }
        public string Ad { get; set; }
        public int Uzmanlik { get; set;  }
        //public PersonelMusaitlik PersonelMusaitlik { get; set; }
        //[ForeignKey(nameof(Islem))]
        //public int IslemId { get; set; } 
        public Islem Islem { get; set; }
        public ICollection<PersonelMusaitlik> PersonelMusaitliks { get; set; }
        public ICollection<RandevuPersonel> Randevus { get; set; }
    }
}
