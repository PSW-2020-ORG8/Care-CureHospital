using Backend.Model.AllActors;
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
        public DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public DbSet<MedicalExaminationReport> MedicalExaminationReport { get; set; }
        public DbSet<MedicalExaminationReport> Prescriptions { get; set; }
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
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Petar", Surname = "Petrovic", ParentName = "Zika", Gender = Gender.Male, IdentityCard = "123123123", HealthInsuranceCard = "32312312312", Jmbg = "13312312312312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2000,1,1,3,3,3), ContactNumber = "063554533", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, CityId = 1 },
                new Patient { Id = 2, Name = "Zika", Surname = "Zikic", ParentName = "Pera", Gender = Gender.Male, IdentityCard = "124123123", HealthInsuranceCard = "712312312312", Jmbg = "12342312312312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2001, 1, 1, 3, 3, 3), ContactNumber = "0635235333", EMail = "zika@gmail.com", Username = "zika", Password = "123", GuestAccount = false, CityId = 2 },
                new Patient { Id = 3, Name = "Mica", Surname = "Micic", ParentName = "Jelena", Gender = Gender.Male, IdentityCard = "163123123", HealthInsuranceCard = "62312312312", Jmbg = "12312512312312", BloodGroup = BloodGroup.Unknown, DateOfBirth = new DateTime(2002, 1, 1, 3, 3, 3), ContactNumber = "0635557673", EMail = "mica@gmail.com", Username = "mica", Password = "123", GuestAccount = false, CityId = 1 },
                new Patient { Id = 4, Name = "Luna", Surname = "Lunic", ParentName = "Jovan", Gender = Gender.Female, IdentityCard = "127123123", HealthInsuranceCard = "52312312312", Jmbg = "12312316712312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "063555356", EMail = "luna@gmail.com", Username = "luna", Password = "123", GuestAccount = false, CityId = 2 }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Username = "milan", Password = "123", Name = "Milan", Surname = "Petrovic", Jmbg = "13312312312312", DateOfBirth = new DateTime(2000, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "milan@gmail.com", CityId = 2, SpecialitationId = 1 },
                new Doctor { Id = 2, Username = "aca", Password = "123", Name = "Aleksandar", Surname = "Aleksic", Jmbg = "13212312312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "aca@gmail.com", CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 3, Username = "jovan", Password = "123", Name = "Jovan", Surname = "Jovic", Jmbg = "13312367312312", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "jovan@gmail.com", CityId = 2, SpecialitationId = 2 },
                new Doctor { Id = 4, Username = "nikola", Password = "123", Name = "Nikola", Surname = "Nikic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "nikola@gmail.com", CityId = 1, SpecialitationId = 1 }
           );

            modelBuilder.Entity<Specialitation>().HasData(
                new Specialitation { Id = 1, SpecialitationForDoctor = "Lekar opste prakse" },
                new Specialitation { Id = 2, SpecialitationForDoctor = "Hirurg" }
            );           

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { Id = 1, PatientId = 1, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = false },
                new MedicalRecord { Id = 2, PatientId = 2, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true },
                new MedicalRecord { Id = 3, PatientId = 3, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true },
                new MedicalRecord { Id = 4, PatientId = 4, AnamnesisId = 1, Allergies = new List<Allergies>(), Medicaments = new List<Medicament>(), ActiveMedicalRecord = true }
            );

            modelBuilder.Entity<MedicalExamination>().HasData(
                new MedicalExamination { Id = 1, Urgency = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 1, DoctorId = 1, PatientId = 2 },
                new MedicalExamination { Id = 2, Urgency = false, ShortDescription = "Pacijent je imao glavobolju", RoomId = 2, DoctorId = 2, PatientId = 1 },
                new MedicalExamination { Id = 3, Urgency = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 2, PatientId = 3 },
                new MedicalExamination { Id = 4, Urgency = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 2, DoctorId = 3, PatientId = 1 },
                new MedicalExamination { Id = 5, Urgency = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 2, PatientId = 3 },
                new MedicalExamination { Id = 6, Urgency = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 4, PatientId = 3 }
            );

            modelBuilder.Entity<MedicalExaminationReport>().HasData(
                new MedicalExaminationReport { Id = 1, Comment = "Pacijent je dobro i nema vecih problema", PublishingDate = new DateTime(2020, 10, 10, 10, 30, 0), MedicalExaminationId = 1 },
                new MedicalExaminationReport { Id = 2, Comment = "Pacijent je veoma dobro i nema vecih problema", PublishingDate = new DateTime(2020, 11, 23, 10, 30, 0), MedicalExaminationId = 2 },
                new MedicalExaminationReport { Id = 3, Comment = "Pacijent ima virus", PublishingDate = new DateTime(2020, 9, 12, 10, 30, 0), MedicalExaminationId = 3 },
                new MedicalExaminationReport { Id = 4, Comment = "Pacijent je lose", PublishingDate = new DateTime(2020, 10, 14, 10, 30, 0), MedicalExaminationId = 3 },
                new MedicalExaminationReport { Id = 5, Comment = "Pacijent ima virus", PublishingDate = new DateTime(2020, 11, 18, 10, 30, 0), MedicalExaminationId = 3 }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), MedicalExaminationId = 1, Medicaments = new List<Medicament>() },
                new Prescription { Id = 2, Comment = "Svakodnevno koristite prepisani lek", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), MedicalExaminationId = 3, Medicaments = new List<Medicament>() },
                new Prescription { Id = 3, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), MedicalExaminationId = 2, Medicaments = new List<Medicament>() },
                new Prescription { Id = 4, Comment = "Ne preskacite konzumiranje leka", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), MedicalExaminationId = 2, Medicaments = new List<Medicament>() },
                new Prescription { Id = 5, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), MedicalExaminationId = 1, Medicaments = new List<Medicament>() }
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { Id = 1, Code = "L123", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 1, PrescriptionId = 1 },
                new Medicament { Id = 2, Code = "L233", Name = "Panadol", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 2, PrescriptionId = 1 },
                new Medicament { Id = 3, Code = "L523", Name = "Paracetamol", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 3, PrescriptionId = 3 },
                new Medicament { Id = 4, Code = "L423", Name = "Vitamin B", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 4, PrescriptionId = 2 },
                new Medicament { Id = 5, Code = "L233", Name = "Panadol", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 14, Ingredients = "sastojak1, sastojak2, sastojak3", MedicalRecordId = 1, PrescriptionId = 2 }
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
                new Allergies { Id = 2, Name = "Brufen", MedicalRecordId = 3 },
                new Allergies { Id = 3, Name = "Panadol", MedicalRecordId = 2 },
                new Allergies { Id = 4, Name = "Ambrozija", MedicalRecordId = 1 }
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
                new City { Id = 1, Name = "Beograd", Address = "Brace Jerkovic 1", PostCode = 11000, CountryId = 1 },
                new City { Id = 2, Name = "Novi Sad", Address = "Bulevar Cara Lazara 1", PostCode = 22100, CountryId = 1 }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Srbija" }
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
        }
    }
}
