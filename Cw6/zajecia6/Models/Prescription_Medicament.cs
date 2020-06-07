using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zajecia6.Models
{
    public class Prescription_Medicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public Prescription Prescription { get; set; }
        public Medicament Medicament { get; set; }


        [Required]
        public int Dose { get; set; }

        [Required]
        [MaxLength(100)]
        public string Details { get; set; }
    }
}
