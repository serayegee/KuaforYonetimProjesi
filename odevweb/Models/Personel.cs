using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{
    public class Personel
    {
        public int PersonelId { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunludur.")]

        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]

        public string Soyad { get; set; }
        public string Uzmanlik { get; set;  }
        //public PersonelMusaitlik PersonelMusaitlik { get; set; }
        [ForeignKey(nameof(Islem))]

        [Required(ErrorMessage = "Id alanı zorunludur.")]

        public int IslemId { get; set; } 
        public Islem Islem { get; set; }
        public ICollection<PersonelMusaitlik> PersonelMusaitliks { get; set; }
        public ICollection<RandevuPersonel> Randevus { get; set; }
    }
}
