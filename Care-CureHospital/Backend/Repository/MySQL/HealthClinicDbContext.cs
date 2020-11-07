using Backend.Model.BlogAndNotification;
using Microsoft.EntityFrameworkCore;
using Model.AllActors;
using Model.DoctorMenager;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Repository.MySQL
{
    public class HealthClinicDbContext : DbContext
    {
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Allergies> Allergiess { get; set; }
        public DbSet<Anamnesis> Anamnesies { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Diagnosis> Diagnosies { get; set; }
        public DbSet<Symptoms> Symptomes { get; set; }

        public HealthClinicDbContext() : base() { }
        public HealthClinicDbContext(DbContextOptions<HealthClinicDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HealthClinicDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Patient>()
            .HasOne(b => b.MedicalRecord)
            .WithOne(i => i.Patient)
            .HasForeignKey<MedicalRecord>(b => b.id);

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { id = 1, Patient = null, Anamnesis = null, Allergies = new List<Allergies>(), Medicament = new List<Medicament>(), patientID = 1, anamnesisID = 1}
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { id = 1, Code = "c35", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3" }
            );

            modelBuilder.Entity<Allergies>().HasData(
                new Allergies { id = 1, Name = "penicilin" }
            );

            modelBuilder.Entity<City>().HasData(
                new City { id = 1, Name = "Beograd", Country = null, Adress = null, PostCode = 11000, CountryID = 1 }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { id = 1, Name = "Srbija", Code = "SRB" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Petar", Surname = "Petrovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordID = 1, cityID = 1 },
                new Patient { Id = 2, Name = "Milos", Surname = "Mitrovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordID = 1, cityID = 1 },
                new Patient { Id = 3, Name = "Jovan", Surname = "Jovanovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordID = 1, cityID = 1 },
                new Patient { Id = 4, Name = "Milica", Surname = "Micic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordID = 1, cityID = 1 }
            );
            modelBuilder.Entity<PatientFeedback>().HasData(
                            new PatientFeedback { Id = 1, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(), IsForPublishing = true, IsPublished = true, IsAnonymous = false, PatientID = 1 },
                            new PatientFeedback { Id = 2, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(), IsForPublishing = true, IsPublished = true, IsAnonymous = true, PatientID = 2 },
                            new PatientFeedback { Id = 3, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientID = 3 },
                            new PatientFeedback { Id = 4, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientID = 4 },
                            new PatientFeedback { Id = 5, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientID = 2 },
                            new PatientFeedback { Id = 6, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientID = 4 }
                        );

            modelBuilder.Entity<Anamnesis>().HasData(
              new Anamnesis { id = 1, Description = "pacijent je dobro", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() }
            );

            modelBuilder.Entity<Symptoms>().HasData(
                new Symptoms { id = 1, Name = "temperatura" },
                new Symptoms { id = 3, Name = "kijanje" }
            );

            modelBuilder.Entity<Diagnosis>().HasData(
                new Diagnosis { id = 1, Name = "prehlada" }
            );

        }
    }
}
