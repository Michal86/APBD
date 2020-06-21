using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.Models
{
    [Table("Zamowienie")]
    public class Zamowienie
    {
        [Key] public int ZamowienieId { get; set; }
        [Required] public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        [MaxLength(300)] public string Uwagi { get; set; }


        //---
        public int KlientId { get; set; }
        public Klient Klient { get; set; }

        public int PracownikId { get; set; }
        public Pracownik Pracownik { get; set; }

        public List<Zamowienie_WyrobCukierniczy>  Zam_WyrobCukier { get; set; }


    }
}
