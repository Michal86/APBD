using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zajecia6.Models
{
    public class HospitalContext : DbContext
    {
        // Entities
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        //Constructor
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }
        //----------------



        //----------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.PrescriptionMedicament)
                .WithOne(p => p.Prescription)
                .HasForeignKey<Prescription_Medicament>(pm => pm.IdPrescription);


            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Ferdek",
                    LastName = "Kiepski",
                    Email = "FerdekKiepski@gmail.com"
                }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Michał",
                    LastName = "Testowy",
                    BirthDate = new DateTime(1986, 01, 01)
                }
            );

        }
    }
}
