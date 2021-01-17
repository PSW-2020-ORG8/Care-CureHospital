using Microsoft.EntityFrameworkCore;
using ReportMicroservice.Domain;
using System;

namespace ReportMicroservice.DataBase
{
    public class ReportDataBaseContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public ReportDataBaseContext() : base() { }
        public ReportDataBaseContext(DbContextOptions<ReportDataBaseContext> options) : base(options) { }

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
            modelBuilder.Entity<Report>().HasData(
                new Report { Id = 1, MedicamentId = 1, MedicamentName = "Aspirin", Quantity = 10, FromDate = new DateTime(2019, 5, 1, 6, 30, 0), ToDate = new DateTime(2019, 10, 1, 6, 10, 0) },
                new Report { Id = 2, MedicamentId = 2, MedicamentName = "Brufen", Quantity = 15, FromDate = new DateTime(2020, 10, 30, 10, 30, 0), ToDate = new DateTime(2020, 2, 5, 6, 10, 0) },
                new Report { Id = 3, MedicamentId = 4, MedicamentName = "Vitamin B", Quantity = 120, FromDate = new DateTime(2019, 1, 10, 3, 30, 0), ToDate = new DateTime(2019, 5, 10, 6, 30, 0) },
                new Report { Id = 4, MedicamentId = 3, MedicamentName = "Paracetamol", Quantity = 24, FromDate = new DateTime(2020, 1, 5, 8, 30, 0), ToDate = new DateTime(2020, 12, 10, 6, 30, 0) }
            );
        }
    }
}
