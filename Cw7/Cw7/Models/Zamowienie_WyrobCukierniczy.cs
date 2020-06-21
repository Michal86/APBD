using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.Models
{
    public class Zamowienie_WyrobCukierniczy
    {

        public int WyrobCukierniczyId { get; set; }
        public WyrobCukierniczy WyrobCukierniczy { get; set; }

        public int ZamowienieId { get; set; }
        public Zamowienie Zamowienie { get; set; }



        //---
        [Required] public int Ilosc { get; set; }
        [MaxLength(300)] public string Uwagi { get; set; }
    }
}
