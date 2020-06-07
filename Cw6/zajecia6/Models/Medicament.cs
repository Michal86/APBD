using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace zajecia6.Models
{
    public class Medicament
    {
        [Key]
        public int IdMedicament { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }


        public Prescription Prescription { get; set; }
    }
}
