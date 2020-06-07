using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.Models
{
    [Table("Zamowienie_WyrobCukierniczy")]
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdZamowienia { get; set; }
        public Zamowienie Zamowienie { get; set; }

        public int IdWyrobuCukierniczego { get; set; }
        public WyrobCukierniczy WyrobCukierniczy { get; set; }


        //---
        [Required] public int Ilosc { get; set; }
        [MaxLength(300)] public string Uwagi { get; set; }
    }
}
