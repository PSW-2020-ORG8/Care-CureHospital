using Microsoft.EntityFrameworkCore;
using PharmacyMicroservice.Domain;
using System;

namespace PharmacyMicroservice.DataBase
{
    public class PharmacyDataBaseContext : DbContext
    {
        public DbSet<Pharmacies> Pharmacies { get; set; }
        public DbSet<EndPoint> EndPoints { get; set; }
        public PharmacyDataBaseContext() : base() { }
        public PharmacyDataBaseContext(DbContextOptions<PharmacyDataBaseContext> options) : base(options) { }

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
            modelBuilder.Entity<Pharmacies>().HasData(
                new Pharmacies { Id = 1, Name = "Jankovic", Key = new APIKey() , Link = new EndPoint()},
                new Pharmacies { Id = 2, Name = "Benu", Key = new APIKey(), Link = new EndPoint() },
                new Pharmacies { Id = 3, Name = "Tilia", Key = new APIKey(), Link = new EndPoint() }
            );

            modelBuilder.Entity<EndPoint>().HasData(
               new EndPoint { Link = "jankovic.com" },
               new EndPoint { Link = "benu.com" },
               new EndPoint { Link = "tilia.com" }
            );

            modelBuilder.Entity<APIKey>().HasData(
                new APIKey { Key = "1234" },
                new APIKey { Key = "5678" },
                new APIKey { Key = "9101112" }
                );
        }
    }
}