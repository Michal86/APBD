using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.Models
{
    public class Pracownik
    {
        [Key] public int IdPracownik { get; set; }
        [MaxLength(50)] public string Imie { get; set; }
        [MaxLength(60)] public string Nazwisko { get; set; }


        public List<Zamowienie> Zamowienia { get; set; }
    }
}
