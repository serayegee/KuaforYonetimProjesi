namespace odevweb.Models
{
    public class Personel
    {
        public int PersonelId { get; set; }
        public string Ad { get; set; }
        public int Uzmanlik { get; set;  }
        //public PersonelMusaitlik PersonelMusaitlik { get; set; }
        public ICollection<PersonelMusaitlik> PersonelMusaitliks { get; set; }
    }
}
