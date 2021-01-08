using EPrescriptionMicroservice.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescriptionMicroservice.DataBase
{
    public class EPrescriptionDataBaseContext : DbContext
    {
        public DbSet<EPrescription> EPrescriptions { get; set; }
        public EPrescriptionDataBaseContext() : base() { }
        public EPrescriptionDataBaseContext(DbContextOptions<EPrescriptionDataBaseContext> options) : base(options) { }

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
            modelBuilder.Entity<EPrescription>().HasData(
                new EPrescription { Id = 1, PatientId = 1, PatientName = "Petar", Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 11, 30, 10, 30, 0), MedicamentName = "Aspirin" },
                new EPrescription { Id = 2, PatientId = 2, PatientName = "Mica", Comment = "Svakodnevno koristite prepisani lek", PublishingDate = new DateTime(2020, 09, 12, 10, 30, 0), MedicamentName = "Brufen" },
                new EPrescription { Id = 3, PatientId = 3, PatientName = "Zika", Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 12, 25, 10, 30, 0), MedicamentName = "Vitamin B" },
                new EPrescription { Id = 4, PatientId = 5, PatientName = "Ivan", Comment = "Ne preskacite konzumiranje leka", PublishingDate = new DateTime(2020, 10, 12, 03, 30, 0), MedicamentName = "Panadol" },
                new EPrescription { Id = 5, PatientId = 6, PatientName = "Marko", Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 11, 26, 10, 30, 0), MedicamentName = "Andol" }
              );
        }
    }
}
