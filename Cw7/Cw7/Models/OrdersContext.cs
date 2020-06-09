using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Cw7.Models
{
    public class OrdersContext : DbContext
    {
        public DbSet<Klient> Klienci {get; set;}
        public DbSet<Pracownik> Pracownicy {get; set;}
        public DbSet<Zamowienie> Zamowienia {get; set;}
        public DbSet<Zamowienie_WyrobCukierniczy> Zam_WCukiericzy {get; set;}
        public DbSet<WyrobCukierniczy> WyrCukierniczy {get; set;}


        public OrdersContext(DbContextOptions options) : base(options)
        {
        }


        //OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zamowienie>()
                .HasOne<Klient>(z => z.Klient)
                .WithMany(k => k.Zamowienia)
                .HasForeignKey(zi => zi.IdKlient);

            modelBuilder.Entity<Zamowienie>()
                .HasOne<Pracownik>(z => z.Pracownik)
                .WithMany(p => p.Zamowienia)
                .HasForeignKey(zi => zi.IdPracownik);


            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
                .HasKey(zwc => new { zwc.IdWyrobuCukierniczego, zwc.IdZamowienia });


        }
               
    }
}
