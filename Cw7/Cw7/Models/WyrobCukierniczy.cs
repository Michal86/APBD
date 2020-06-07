using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.Models
{
    [Table("WyrobCukierniczy")]
    public class WyrobCukierniczy
    {
        [Key] public int IdWyrobuCukierniczego { get; set; }
        [MaxLength(200)] public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        [MaxLength(40)] public string Typ { get; set; }


    }
}
