﻿using Backend.Model.BlogAndNotification;
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
            .HasForeignKey<MedicalRecord>(b => b.id);

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Petar", Surname = "Petrovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordID = 1, cityID = 1 },
                new Patient { Id = 2, Name = "Milos", Surname = "Mitrovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordID = 2, cityID = 1 },
                new Patient { Id = 3, Name = "Jovan", Surname = "Jovanovic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordID = 3, cityID = 1 },
                new Patient { Id = 4, Name = "Milica", Surname = "Micic", Jmbg = "123", ContactNumber = "063555333", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, MedicalRecordID = 4, cityID = 1 }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Username = "pera", Password = "123", Name = "Petar", Surname = "Petrovic", Jmbg = "123", DateOfBirth = new DateTime(), ContactNumber = "06345111144", EMail = "pera@gmail.com", cityID = 1, specialitationID = 1 },
                new Doctor { Id = 2, Username = "pera", Password = "123", Name = "Petar", Surname = "Petrovic", Jmbg = "123", DateOfBirth = new DateTime(), ContactNumber = "06345111144", EMail = "pera@gmail.com", cityID = 1, specialitationID = 1 },
                new Doctor { Id = 3, Username = "pera", Password = "123", Name = "Petar", Surname = "Petrovic", Jmbg = "123", DateOfBirth = new DateTime(), ContactNumber = "06345111144", EMail = "pera@gmail.com", cityID = 1, specialitationID = 1 },
                new Doctor { Id = 4, Username = "pera", Password = "123", Name = "Petar", Surname = "Petrovic", Jmbg = "123", DateOfBirth = new DateTime(), ContactNumber = "06345111144", EMail = "pera@gmail.com", cityID = 1, specialitationID = 1 }
           );

            modelBuilder.Entity<Specialitation>().HasData(
                new Specialitation { Id = 1, SpecialitationForDoctor = "Hirurg" }
            );           

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { id = 1, patientID = 1, anamnesisID = 1, Allergies = new List<Allergies>(), Medicament = new List<Medicament>() },
                new MedicalRecord { id = 2, patientID = 2, anamnesisID = 1, Allergies = new List<Allergies>(), Medicament = new List<Medicament>() },
                new MedicalRecord { id = 3, patientID = 3, anamnesisID = 1, Allergies = new List<Allergies>(), Medicament = new List<Medicament>() },
                new MedicalRecord { id = 4, patientID = 4, anamnesisID = 1, Allergies = new List<Allergies>(), Medicament = new List<Medicament>() }
            );

            modelBuilder.Entity<MedicalExamination>().HasData(
                new MedicalExamination { id = 1, Urgency = false, ShortDescription = "Sve je bilo uredu na pregledu", roomID = 1, doctorID = 1, patientID = 2 },
                new MedicalExamination { id = 2, Urgency = false, ShortDescription = "Sve je bilo uredu na pregledu", roomID = 2, doctorID = 2, patientID = 1 },
                new MedicalExamination { id = 3, Urgency = false, ShortDescription = "Sve je bilo uredu na pregledu", roomID = 3, doctorID = 2, patientID = 3 }
            );

            modelBuilder.Entity<MedicalExaminationReport>().HasData(
                new MedicalExaminationReport { id = 1, Comment = "Pacijent je dobro i nema većih problema", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), medicalExaminationID = 1 },
                new MedicalExaminationReport { id = 2, Comment = "Pacijent je veoma dobro i nema većih problema", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), medicalExaminationID = 2 },
                new MedicalExaminationReport { id = 3, Comment = "Pacijent ima virus", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), medicalExaminationID = 3 }
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { id = 1, Code = "L123", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", medicalRecordID = 1 },
                new Medicament { id = 2, Code = "L233", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", medicalRecordID = 2 },
                new Medicament { id = 3, Code = "L523", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", medicalRecordID = 3 },
                new Medicament { id = 4, Code = "L423", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", medicalRecordID = 4 },
                new Medicament { id = 5, Code = "L423", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", medicalRecordID = 2 },
                new Medicament { id = 6, Code = "L423", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", medicalRecordID = 1 },
                new Medicament { id = 7, Code = "L423", Name = "Brufen", Producer = "Hemofarm", StateOfValidation = State.Confirmed, Quantity = 10, Ingredients = "sastojak1, sastojak2, sastojak3", medicalRecordID = 1 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { id = 1, RoomID = "101", typeOfRoomID = 1, Equipment = new List<InventaryRoom>() },
                new Room { id = 2, RoomID = "201", typeOfRoomID = 1, Equipment = new List<InventaryRoom>() },
                new Room { id = 3, RoomID = "301", typeOfRoomID = 1, Equipment = new List<InventaryRoom>() }
            );

            modelBuilder.Entity<InventaryRoom>().HasData(
               new InventaryRoom { id = 1, Name = "Stolovi", Quantity = 1, roomID = 1 },
               new InventaryRoom { id = 2, Name = "Stolice", Quantity = 1, roomID = 1 },
               new InventaryRoom { id = 3, Name = "Kreveti", Quantity = 1, roomID = 2 }
           );

            modelBuilder.Entity<TypeOfRoom>().HasData(
                new TypeOfRoom { id = 1, NameOfType = "Soba za preglede" },
                new TypeOfRoom { id = 2, NameOfType = "Soba za operacije" }
            );

            modelBuilder.Entity<Allergies>().HasData(
                new Allergies { id = 1, Name = "Penicilin", medicalRecordID = 1 },
                new Allergies { id = 2, Name = "Penicilin", medicalRecordID = 3 },
                new Allergies { id = 3, Name = "Penicilin", medicalRecordID = 2 },
                new Allergies { id = 4, Name = "Penicilin", medicalRecordID = 1 }
            );

            modelBuilder.Entity<Anamnesis>().HasData(
              new Anamnesis { id = 1, Description = "Pacijent je dobro", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() },
              new Anamnesis { id = 2, Description = "Pacijent je loše", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() },
              new Anamnesis { id = 3, Description = "Pacijent je vrlo dobro", Diagnosis = new List<Diagnosis>(), Symptoms = new List<Symptoms>() }
            );

            modelBuilder.Entity<Symptoms>().HasData(
                new Symptoms { id = 1, Name = "Temperatura", anamnesisID = 2 },
                new Symptoms { id = 2, Name = "Kašalj", anamnesisID = 1 },
                new Symptoms { id = 3, Name = "Glavobolja", anamnesisID = 2 }
            );

            modelBuilder.Entity<Diagnosis>().HasData(
                new Diagnosis { id = 1, Name = "Prehlada", anamnesisID = 1 },
                new Diagnosis { id = 2, Name = "Virus", anamnesisID = 2 },
                new Diagnosis { id = 3, Name = "Migrena", anamnesisID = 2 }
            );

            modelBuilder.Entity<City>().HasData(
                new City { id = 1, Name = "Beograd", Country = null, Adress = null, PostCode = 11000, CountryID = 1 }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { id = 1, Name = "Srbija", Code = "SRB" }
            );
            
            modelBuilder.Entity<PatientFeedback>().HasData(
                new PatientFeedback { Id = 1, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), IsForPublishing = true, IsPublished = true, IsAnonymous = false, PatientID = 1 },
                new PatientFeedback { Id = 2, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 8, 15, 9, 17, 0), IsForPublishing = true, IsPublished = true, IsAnonymous = true, PatientID = 2 },
                new PatientFeedback { Id = 3, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 9, 3, 11, 30, 0), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientID = 3 },
                new PatientFeedback { Id = 4, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientID = 4 },
                new PatientFeedback { Id = 5, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 18, 7, 30, 0), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientID = 2 },
                new PatientFeedback { Id = 6, Text = "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.", PublishingDate = new DateTime(2020, 10, 15, 6, 30, 0), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientID = 4 }
            );

            modelBuilder.Entity<Survey>().HasData(
                new Survey { id = 1, Title = "Naslov", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), CommentSurvey = "Sve je super u bolnici", medicalExaminationID = 1, Question = new List<Question>() },
                new Survey { id = 2, Title = "Naslov", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), CommentSurvey = "Sve je super u bolnici", medicalExaminationID = 2, Question = new List<Question>() }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { id = 1, QuestionText = "Pitanje1", answerID = 1, surveyID = 1 },
                new Question { id = 2, QuestionText = "Pitanje2", answerID = 1, surveyID = 1 },
                new Question { id = 3, QuestionText = "Pitanje3", answerID = 1, surveyID = 2 },
                new Question { id = 4, QuestionText = "Pitanje4", answerID = 1, surveyID = 2 },
                new Question { id = 5, QuestionText = "Pitanje5", answerID = 1, surveyID = 1 }
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
