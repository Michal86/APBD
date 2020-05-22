using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Models
{
    public class EnrollmentDTO
    {
        [Required]
        public string IndexNumber { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Name { get; set; }       //studies -> "IT"
    }
}
