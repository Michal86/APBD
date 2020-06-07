using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zajecia6.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Duedate { get; set; }

        //----
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }

        public int IdPatient { get; set; }
        public Patient Patient { get; set; }

        public Prescription_Medicament PrescriptionMedicament { get; set; }
    }
}
