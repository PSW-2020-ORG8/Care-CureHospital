using Backend.Model.BlogAndNotification;
using Backend.Model.PatientDoctor;
using Microsoft.EntityFrameworkCore;
using Model.AllActors;
using Model.Doctor;
using Model.DoctorMenager;
using Model.Manager;
using Model.Patient;
using Model.PatientDoctor;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Repository.MySQL
{
    public class HealthClinicDbContext : DbContext
    {
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Patient> Doctors { get; set; }
        public DbSet<Specialitation> Specialitations { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalExamination> MedicalExamination { get; set; }
        public DbSet<MedicalExaminationReport> MedicalExaminationReport { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<InventaryRoom> InventaryRoom { get; set; }
        public DbSet<TypeOfRoom> TypesOfRoom { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Anamnesis> Anamnesies { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Diagnosis> Diagnosies { get; set; }
        public DbSet<Symptoms> Symptomes { get; set; }
        public DbSet<Surgery> Survey { get; set; }
        public DbSet<Question> Question { get; set; }

        public HealthClinicDbContext() : base() { }
        public HealthClinicDbContext(DbContextOptions<HealthClinicDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseMySql("server=localhost;port=3306;database=HealthClinicDB;user=root;password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Patient>()
            .HasOne(b => b.MedicalRecord)
            .WithOne(i => i.Patient)
            .HasForeignKey<MedicalRecord>(b => b.Id);

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Petar", Surname = "Petrovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordId = 1, CityId = 1 },
                new Patient { Id = 2, Name = "Milos", Surname = "Mitrovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordId = 2, CityId = 1 },
                new Patient { Id = 3, Name = "Jovan", Surname = "Jovanovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordId = 3, CityId = 1 },
                new Patient { Id = 4, Name = "Milica", Surname = "Micic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordId = 4, CityId = 1 }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Username = "pera", Password = "123", Name = "Petar", Surname = "Petrovic", Jmbg = "123", DateOfBirth = new DateTime(), ContactNumber = "06345111144", EMail = "pera@gmail.com", CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 2, Username = "pera", Password = "123", Name = "Petar", Surname = "Petrovic", Jmbg = "123", DateOfBirth = new DateTime(), ContactNumber = "06345111144", EMail = "pera@gmail.com", CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 3, Username = "pera", Password = "123", Name = "Petar", Surname = "Petrovic", Jmbg = "123", DateOfBirth = new DateTime(), ContactNumber = "06345111144", EMail = "pera@gmail.com", CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 4, Username = "pera", Password = "123", Name = "Petar", Surname = "Petrovic", Jmbg = "123", DateOfBirth = new DateTime(), ContactNumber = "06345111144", EMail = "pera@gmail.com", CityId = 1, SpecialitationId = 1 }
           );

            modelBuilder.Entity<Specialitation>().HasData(
                new Specialitation { Id = 1, SpecialitationForDoctor = "Hirurg" }
            );           

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { Id = 1, PatientId = 1, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicament = new List<Medicament>() },
                new MedicalRecord { Id = 2, PatientId = 2, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicament = new List<Medicament>() },
                new MedicalRecord { Id = 3, PatientId = 3, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicament = new List<Medicament>() },
                new MedicalRecord { Id = 4, PatientId = 4, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicament = new List<Medicament>() }
            );

            modelBuilder.Entity<MedicalExamination>().HasData(
                new MedicalExamination { Id = 1, Urgency = false, ShortDescription = "Sve je bilo uredu na pregledu", RoomId = 1, DoctorId = 1, PatientId = 2 },
                new MedicalExamination { Id = 2, Urgency = false, ShortDescription = "Sve je bilo uredu na pregledu", RoomId = 2, DoctorId = 2, PatientId = 1 },
                new MedicalExamination { Id = 3, Urgency = false, ShortDescription = "Sve je bilo uredu na pregledu", RoomId = 3, DoctorId = 2, PatientId = 3 }
            );

            modelBuilder.Entity<MedicalExaminationReport>().HasData(
                new MedicalExaminationReport { Id = 1, Comment = "Pacijent je dobro i nema većih problema", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), MedicalExaminationId = 1 },
                new MedicalExaminationReport { Id = 2, Comment = "Pacijent je veoma dobro i nema većih problema", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), MedicalExaminationId = 2 },
                new MedicalExaminationReport { Id = 3, Comment = "Pacijent ima virus", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), MedicalExaminationId = 3 }
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { Id = 1, Code = "L123", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 1 },
                new Medicament { Id = 2, Code = "L233", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 2 },
                new Medicament { Id = 3, Code = "L523", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 3 },
                new Medicament { Id = 4, Code = "L423", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 4 },
                new Medicament { Id = 5, Code = "L423", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 2 },
                new Medicament { Id = 6, Code = "L423", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 1 },
                new Medicament { Id = 7, Code = "L423", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 1 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomId = "101", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>() },
                new Room { Id = 2, RoomId = "201", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>() },
                new Room { Id = 3, RoomId = "301", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>() }
            );

            modelBuilder.Entity<InventaryRoom>().HasData(
               new InventaryRoom { Id = 1, Name = "Stolovi", Quantity = 1, RoomId = 1 },
               new InventaryRoom { Id = 2, Name = "Stolice", Quantity = 1, RoomId = 1 },
               new InventaryRoom { Id = 3, Name = "Kreveti", Quantity = 1, RoomId = 2 }
           );

            modelBuilder.Entity<TypeOfRoom>().HasData(
                new TypeOfRoom { Id = 1, NameOfType = "Soba za preglede" },
                new TypeOfRoom { Id = 2, NameOfType = "Soba za operacije" }
            );

            modelBuilder.Entity<Allergies>().HasData(
                new Allergies { Id = 1, Name = "Penicilin", MedicalRecordId = 1 },
                new Allergies { Id = 2, Name = "Penicilin", MedicalRecordId = 3 },
                new Allergies { Id = 3, Name = "Penicilin", MedicalRecordId = 2 },
                new Allergies { Id = 4, Name = "Penicilin", MedicalRecordId = 1 }
            );

            modelBuilder.Entity<Anamnesis>().HasData(
              new Anamnesis { Id = 1, Description = "Pacijent je dobro", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() },
              new Anamnesis { Id = 2, Description = "Pacijent je loše", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() },
              new Anamnesis { Id = 3, Description = "Pacijent je vrlo dobro", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() }
            );

            modelBuilder.Entity<Symptoms>().HasData(
                new Symptoms { Id = 1, Name = "Temperatura", AnamnesisId = 2 },
                new Symptoms { Id = 2, Name = "Kašalj", AnamnesisId = 1 },
                new Symptoms { Id = 3, Name = "Glavobolja", AnamnesisId = 2 }
            );

            modelBuilder.Entity<Diagnosis>().HasData(
                new Diagnosis { Id = 1, Name = "Prehlada", AnamnesisId = 1 },
                new Diagnosis { Id = 2, Name = "Virus", AnamnesisId = 2 },
                new Diagnosis { Id = 3, Name = "Migrena", AnamnesisId = 2 }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Beograd", Country = null, Adress = null, PostCode = 11000, CountryId = 1 }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Srbija", Code = "SRB" }
            );
            
            modelBuilder.Entity<PatientFeedback>().HasData(
                new PatientFeedback { Id = 1, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), IsForPublishing = true, IsPublished = true, IsAnonymous = false, PatientId = 1 },
                new PatientFeedback { Id = 2, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 8, 15, 9, 17, 0), IsForPublishing = true, IsPublished = true, IsAnonymous = true, PatientId = 2 },
                new PatientFeedback { Id = 3, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 9, 3, 11, 30, 0), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientId = 3 },
                new PatientFeedback { Id = 4, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientId = 4 },
                new PatientFeedback { Id = 5, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 18, 7, 30, 0), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientId = 2 },
                new PatientFeedback { Id = 6, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 15, 6, 30, 0), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientId = 4 }
            );

            modelBuilder.Entity<Survey>().HasData(
                new Survey { Id = 1, Title = "Naslov", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), CommentSurvey = "Sve je super u bolnici", MedicalExaminationId = 1, Question = new List<Question>() },
                new Survey { Id = 2, Title = "Naslov", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), CommentSurvey = "Sve je super u bolnici", MedicalExaminationId = 2, Question = new List<Question>() }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuestionText = "Pitanje1", AnswerId = 1, SurveyId = 1 },
                new Question { Id = 2, QuestionText = "Pitanje2", AnswerId = 1, SurveyId = 1 },
                new Question { Id = 3, QuestionText = "Pitanje3", AnswerId = 1, SurveyId = 2 },
                new Question { Id = 4, QuestionText = "Pitanje4", AnswerId = 1, SurveyId = 2 },
                new Question { Id = 5, QuestionText = "Pitanje5", AnswerId = 1, SurveyId = 1 }
            );

            /*modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { id = 1, Patient = null, Anamnesis = null, Allergies = new List<Allergies>(), Medicament = new List<Medicament>(), patientID = 1, anamnesisID = 1}
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { id = 1, Code = "c35", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3" }
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
            );*/

        }
    }
}
