using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Domain.SchedulingAppointmentEvents;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventSourcingMicroservice.DataBase
{
    public class ESDataBaseContext : DbContext
    {
        public DbSet<LoginEvent> LoginEvents { get; set; }
        public DbSet<URLEvent> URLEvents { get; set; }
        public DbSet<StartSchedulingAppointmentEvent> StartSchedulingAppointmentEvents { get; set; }
        public DbSet<EndSchedulingAppointmentEvent> EndSchedulingAppointmentEvents { get; set; }
        public DbSet<SchedulingAppointmentStepEvent> SchedulingAppointmentStepEvents { get; set; }

        public ESDataBaseContext()
        {
        }

        public ESDataBaseContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  
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
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA_EVENT") ?? "EventSourcingDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            string sslMode = Environment.GetEnvironmentVariable("DATABASE_SSL_MODE") ?? "None";

            return $"server={server};port={port};database={database};user={user};password={password};";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

