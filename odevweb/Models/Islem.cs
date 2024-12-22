using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace odevweb.Models
{

    public class Islem
    {
        public int IslemId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Islem Ad")]
        public string IslemAd { get; set; }
        public int Sure { get; set; }
        public double Ucret { get; set; }

        public ICollection<RandevuIslem>? Randevus { get; set; }

        public ICollection<Personel>? Personels { get; set; }
    }


}
