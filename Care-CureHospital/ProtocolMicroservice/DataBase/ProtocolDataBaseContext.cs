using Microsoft.EntityFrameworkCore;
using ProtocolMicroservice.Domain;
using System;

namespace ProtocolMicroservice.DataBase
{
    public class ProtocolDataBaseContext : DbContext
    {
        public DbSet<UrgentMedicineOrder> UrgentMedicineOrders { get; set; }
        public ProtocolDataBaseContext() : base() { }
        public ProtocolDataBaseContext(DbContextOptions<ProtocolDataBaseContext> options) : base(options) { }

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
            modelBuilder.Entity<UrgentMedicineOrder>().HasData(
                new UrgentMedicineOrder { Id = 1, Name = "Aspirin", Quantity = 100 },
                new UrgentMedicineOrder { Id = 2, Name = "Brufen",  Quantity = 52 },
                new UrgentMedicineOrder { Id = 3, Name = "Vitamin B", Quantity = 10 }
            );
        }
    }
}