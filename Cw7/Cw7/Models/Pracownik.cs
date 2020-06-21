﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.Models
{
    [Table("Pracownik")]
    public class Pracownik
    {
        [Key] public int PracownikId { get; set; }
        [MaxLength(50)] public string Imie { get; set; }
        [MaxLength(60)] public string Nazwisko { get; set; }


        public List<Zamowienie> Zamowienia { get; set; }
    }
}
