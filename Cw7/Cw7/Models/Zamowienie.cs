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
        [Key] public int IdZamowienia { get; set; }
        [Required] public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        [MaxLength(300)] public string Uwagi { get; set; }


        //---
        public int IdKlient { get; set; }
        public Klient Klient { get; set; }

        public int IdPracownik { get; set; }
        public Pracownik Pracownik { get; set; }

    }
}
