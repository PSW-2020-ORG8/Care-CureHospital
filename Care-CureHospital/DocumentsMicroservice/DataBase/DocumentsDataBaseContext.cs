using DocumentsMicroservice.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.DataBase
{
    public class DocumentsDataBaseContext : DbContext
    {
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalExaminationReport> MedicalExaminationReports { get; set; }
        public DbSet<MedicalExaminationReport> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Anamnesis> Anamnesies { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Diagnosis> Diagnosies { get; set; }
        public DbSet<Symptoms> Symptomes { get; set; }

        public DocumentsDataBaseContext() : base() { }
        public DocumentsDataBaseContext(DbContextOptions<DocumentsDataBaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("* * * * * * * * * * * * *");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseMySql(CreateConnectionStringFromEnvironment());
            }
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "HealthClinicDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            string sslMode = Environment.GetEnvironmentVariable("DATABASE_SSL_MODE") ?? "None";
            Console.WriteLine(server);
            Console.WriteLine(port);
            Console.WriteLine(user);
            Console.WriteLine(password);
            Console.WriteLine(database);
            return $"server={server};port={port};database={database};user={user};password={password};";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { Id = 1, PatientId = 1, AnamnesisId = 1, ActiveMedicalRecord = true },
                new MedicalRecord { Id = 2, PatientId = 2, AnamnesisId = 1, ActiveMedicalRecord = true },
                new MedicalRecord { Id = 3, PatientId = 3, AnamnesisId = 1, ActiveMedicalRecord = true },
                new MedicalRecord { Id = 4, PatientId = 4, AnamnesisId = 1, ActiveMedicalRecord = true },
                new MedicalRecord { Id = 5, PatientId = 5, AnamnesisId = 1, ActiveMedicalRecord = true },
                new MedicalRecord { Id = 6, PatientId = 6, AnamnesisId = 1, ActiveMedicalRecord = true }
            );

            modelBuilder.Entity<MedicalExaminationReport>().HasData(
                new MedicalExaminationReport { Id = 1, Comment = "Pacijent je dobro i nema vecih problema", PublishingDate = new DateTime(2020, 09, 20, 10, 30, 0), MedicalExaminationId = 3 },
                new MedicalExaminationReport { Id = 2, Comment = "Pacijent je veoma dobro i nema vecih problema", PublishingDate = new DateTime(2020, 11, 23, 10, 30, 0), MedicalExaminationId = 4 },
                new MedicalExaminationReport { Id = 3, Comment = "Pacijent ima virus", PublishingDate = new DateTime(2020, 9, 12, 10, 30, 0), MedicalExaminationId = 2 },
                new MedicalExaminationReport { Id = 4, Comment = "Pacijent je lose", PublishingDate = new DateTime(2020, 10, 14, 10, 30, 0), MedicalExaminationId = 2 },
                new MedicalExaminationReport { Id = 5, Comment = "Pacijent ima virus", PublishingDate = new DateTime(2020, 11, 18, 10, 30, 0), MedicalExaminationId = 2 }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 11, 30, 10, 30, 0), MedicalExaminationId = 4 },
                new Prescription { Id = 2, Comment = "Svakodnevno koristite prepisani lek", PublishingDate = new DateTime(2020, 09, 12, 10, 30, 0), MedicalExaminationId = 3 },
                new Prescription { Id = 3, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 12, 25, 10, 30, 0), MedicalExaminationId = 2 },
                new Prescription { Id = 4, Comment = "Ne preskacite konzumiranje leka", PublishingDate = new DateTime(2020, 10, 12, 03, 30, 0), MedicalExaminationId = 2 },
                new Prescription { Id = 5, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 11, 26, 10, 30, 0), MedicalExaminationId = 4 }
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { Id = 1, Name = "Brufen", MedicalRecordId = 1, PrescriptionId = 1 },
                new Medicament { Id = 2, Name = "Panadol", MedicalRecordId = 2, PrescriptionId = 1 },
                new Medicament { Id = 3, Name = "Paracetamol", MedicalRecordId = 3, PrescriptionId = 3 },
                new Medicament { Id = 4, Name = "Vitamin B", MedicalRecordId = 4, PrescriptionId = 2 },
                new Medicament { Id = 5, Name = "Panadol", MedicalRecordId = 1, PrescriptionId = 2 }
            );

            modelBuilder.Entity<Allergies>().HasData(
                new Allergies { Id = 1, Name = "Penicilin", MedicalRecordId = 1 },
                new Allergies { Id = 2, Name = "Brufen", MedicalRecordId = 3 },
                new Allergies { Id = 3, Name = "Panadol", MedicalRecordId = 2 },
                new Allergies { Id = 4, Name = "Ambrozija", MedicalRecordId = 1 }
            );

            modelBuilder.Entity<Anamnesis>().HasData(
              new Anamnesis { Id = 1, Description = "Pacijent je dobro" },
              new Anamnesis { Id = 2, Description = "Pacijent je loše" },
              new Anamnesis { Id = 3, Description = "Pacijent je vrlo dobro" }
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

        }
    }
}
