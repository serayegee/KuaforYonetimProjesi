using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using odevweb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;



namespace odevweb.Models
{
    public class KuaforContext : DbContext
    {

        public DbSet<Islem> Islems { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<PersonelMusaitlik> PersonelMusaitliks { get; set; }
        public DbSet<Randevu> Randevus { get; set; }
        public DbSet<RandevuIslem> RandevuIslems { get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QQFBS32\\SQLEXPRESS;Database=KuaforDb;Trusted_Connection=True");
        }


 

    }


}


