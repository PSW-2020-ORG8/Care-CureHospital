using Microsoft.EntityFrameworkCore;
using System;
using TenderMicroservice.Domain;

namespace TenderMicroservice.DataBase
{
    public class TenderDataBaseContext : DbContext
    {
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public TenderDataBaseContext() : base() { }
        public TenderDataBaseContext(DbContextOptions<TenderDataBaseContext> options) : base(options) { }

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
            modelBuilder.Entity<Tender>().HasData(
                new Tender { Id = 1, MedicamentName = "Aspirin", StartDate = new DateTime(2020, 1, 5, 8, 30, 0), EndDate = new DateTime(2020, 2, 5, 8, 30, 0), Active = true, ChoosenOffer = false },
                new Tender { Id = 2, MedicamentName = "Brufen", StartDate = new DateTime(2021, 1, 7, 8, 30, 0), EndDate = new DateTime(2021, 2, 7, 8, 30, 0), Active = true, ChoosenOffer = false }
            );

            modelBuilder.Entity<Offer>().HasData(
                new Offer { Id = 1, TenderId = 1, PharmacyName = "Jankovic", PharmacyEmail = "pharmacysistem@gmail.com", Price = 205.5, Quantity = 150, Comment = "Ova cena je za preko 100 komada!", ActiveTender = true, Choosen = false },
                new Offer { Id = 2, TenderId = 1, PharmacyName = "Benu", PharmacyEmail = "benupharmacy@gmail.com", Price = 202.4, Quantity = 52, Comment = "Fiksna cena!", ActiveTender = true, Choosen = false }
            );
        }
    }
}
