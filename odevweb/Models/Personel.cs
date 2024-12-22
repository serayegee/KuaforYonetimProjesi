using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odevweb.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MaxLength(100)]
        [Display(Name = "Personel Adı ")]

        public string PersonelAd { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]

        public string PersonelSoyad { get; set; }
        //public string Uzmanlik { get; set;  }
        //public PersonelMusaitlik PersonelMusaitlik { get; set; }
        public int IslemId { get; set; } 
        public Islem Islem { get; set; }
        public ICollection<PersonelMusaitlik>? PersonelMusaitliks { get; set; }
        public ICollection<RandevuPersonel>? Randevus { get; set; }
    }
}
