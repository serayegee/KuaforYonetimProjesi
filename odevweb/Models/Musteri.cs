namespace odevweb.Models
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Telefon { get; set; }
        //public Randevu Randevu { get; set; }
        public ICollection<Randevu> Randevus { get; set; }

    }
}
