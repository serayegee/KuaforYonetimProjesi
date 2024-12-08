using Microsoft.EntityFrameworkCore;
namespace odevweb.Models
{

    public class Islem
    {
        public int IslemId { get; set; }
        public string Ad { get; set; }
        public int Sure { get; set; }
        public double Ucret { get; set; }

    }


}
