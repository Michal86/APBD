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
        public DbSet<Zamowienie_WyrobCukierniczy> Zam_WCukierniczy {get; set;}
        public DbSet<WyrobCukierniczy> WyrCukierniczy {get; set;}


        public OrdersContext(DbContextOptions options) : base(options) { }


        //OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
                .HasKey(zwc => new { zwc.WyrobCukierniczyId, zwc.ZamowienieId });

            //--- dane ---
            var prepKlienci = new List<Klient>();
            var prepPracownicy = new List<Pracownik>();
            var prepZamowienie = new List<Zamowienie>();
            var prepWyrobCukierniczy = new List<WyrobCukierniczy>();
            var prepZamWyrobCukier = new List<Zamowienie_WyrobCukierniczy>();

            var klien1 = new Klient { KlientId = 1, Imie = "Adam", Nazwisko = "Kowalski" };
            prepKlienci.Add(klien1);

            var pracownik1 = new Pracownik { PracownikId = 1, Imie = "Krystian", Nazwisko = "Teodorski" };
            prepPracownicy.Add(pracownik1);

            var wyrob1 = new WyrobCukierniczy { WyrobCukierniczyId = 1, Nazwa = "Pączek", Typ = "Słodycz", CenaZaSzt = 10.0f };
            prepWyrobCukierniczy.Add(wyrob1);

            var zamowienie1 = new Zamowienie
            {
                DataPrzyjecia = DateTime.Now,
                DataRealizacji = DateTime.Now,
                KlientId = klien1.KlientId,
                PracownikId = pracownik1.PracownikId,
                ZamowienieId = 1
            };
            prepZamowienie.Add(zamowienie1);

            var zamowienieWyrob1 = new Zamowienie_WyrobCukierniczy
            {
                WyrobCukierniczyId = wyrob1.WyrobCukierniczyId,
                ZamowienieId = zamowienie1.ZamowienieId,
                Ilosc = 2
            };
            prepZamWyrobCukier.Add(zamowienieWyrob1);

            //---
            modelBuilder.Entity<Klient>().HasData(prepKlienci);
            modelBuilder.Entity<Pracownik>().HasData(prepPracownicy);
            modelBuilder.Entity<Zamowienie>().HasData(prepZamowienie);
            modelBuilder.Entity<WyrobCukierniczy>().HasData(prepWyrobCukierniczy);
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>().HasData(prepZamWyrobCukier);

            //-----------------


        }

    }
}
