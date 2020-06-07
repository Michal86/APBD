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
            modelBuilder.Entity<Zamowienie>().HasKey(x => new {x.Klient, x.IdPracownik });



        }
               
    }
}
