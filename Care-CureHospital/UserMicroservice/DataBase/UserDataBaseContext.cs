using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.Domain;
using UserMicroservice.Domain.Enum;

namespace UserMicroservice.DataBase
{
    public class UserDataBaseContext : DbContext
    {
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<SystemAdministrator> SystemAdministrators { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public UserDataBaseContext()
        {

        }

        public UserDataBaseContext(DbContextOptions<DbContext> options): base(options) 
        { 
            
        }
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
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Petar", Surname = "Petrovic", ParentName = "Zika", Gender = Gender.Male, IdentityCard = "123123123", HealthInsuranceCard = "32312312312", Jmbg = "13312312312312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2000, 1, 1, 3, 3, 3), ContactNumber = "063554533", EMail = "pera@gmail.com", Username = "pera", Password = "123", GuestAccount = false, CityId = 1, Blocked = false, Malicious = false, Role = "Patient" },
                new Patient { Id = 2, Name = "Zika", Surname = "Zikic", ParentName = "Pera", Gender = Gender.Male, IdentityCard = "124123123", HealthInsuranceCard = "712312312312", Jmbg = "12342312312312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2001, 1, 1, 3, 3, 3), ContactNumber = "0635235333", EMail = "zika@gmail.com", Username = "zika", Password = "123", GuestAccount = false, CityId = 2, Blocked = false, Malicious = false, Role = "Patient" },
                new Patient { Id = 3, Name = "Mica", Surname = "Micic", ParentName = "Jelena", Gender = Gender.Male, IdentityCard = "163123123", HealthInsuranceCard = "62312312312", Jmbg = "12312512312312", BloodGroup = BloodGroup.Unknown, DateOfBirth = new DateTime(2002, 1, 1, 3, 3, 3), ContactNumber = "0635557673", EMail = "mica@gmail.com", Username = "mica", Password = "123", GuestAccount = false, CityId = 1, Blocked = false, Malicious = false, Role = "Patient" },
                new Patient { Id = 4, Name = "Luna", Surname = "Lunic", ParentName = "Jovan", Gender = Gender.Female, IdentityCard = "127123123", HealthInsuranceCard = "52312312312", Jmbg = "12312316712312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "063555356", EMail = "luna@gmail.com", Username = "luna", Password = "123", GuestAccount = false, CityId = 2, Blocked = false, Malicious = false, Role = "Patient" },
                new Patient { Id = 5, Name = "Ivan", Surname = "Ivanovic", ParentName = "Luka", Gender = Gender.Male, IdentityCard = "127199123", HealthInsuranceCard = "52318812312", Jmbg = "12344316712312", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "063775356", EMail = "ivan@gmail.com", Username = "ivan", Password = "123", GuestAccount = false, CityId = 2, Blocked = false, Malicious = true, Role = "Patient" },
                new Patient { Id = 6, Name = "Marko", Surname = "Markovic", ParentName = "Jovan", Gender = Gender.Male, IdentityCard = "127123333", HealthInsuranceCard = "52312312311", Jmbg = "12312316712344", BloodGroup = BloodGroup.AbMinus, DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "063555312", EMail = "marko@gmail.com", Username = "marko", Password = "123", GuestAccount = false, CityId = 2, Blocked = false, Malicious = true, Role = "Patient" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Username = "milan", Password = "123", Name = "Milan", Surname = "Petrovic", Jmbg = "13312312312312", DateOfBirth = new DateTime(2000, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "milan@gmail.com", CityId = 2, SpecialitationId = 1 },
                new Doctor { Id = 2, Username = "aca", Password = "123", Name = "Aleksandar", Surname = "Aleksic", Jmbg = "13212312312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "aca@gmail.com", CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 3, Username = "jovan", Password = "123", Name = "Jovan", Surname = "Jovic", Jmbg = "13312367312312", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "jovan@gmail.com", CityId = 2, SpecialitationId = 2 },
                new Doctor { Id = 4, Username = "nikola", Password = "123", Name = "Nikola", Surname = "Nikic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "nikola@gmail.com", CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 5, Username = "mihajlo", Password = "123", Name = "Mihajlo", Surname = "Mihajlovic", Jmbg = "13312367312312", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "mihajlo@gmail.com", CityId = 2, SpecialitationId = 3 },
                new Doctor { Id = 6, Username = "vuk", Password = "123", Name = "Vuk", Surname = "Vukic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "vuk@gmail.com", CityId = 1, SpecialitationId = 3 },
                new Doctor { Id = 7, Username = "helena", Password = "123", Name = "Helena", Surname = "Kostic", Jmbg = "13312367312312", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "helena@gmail.com", CityId = 2, SpecialitationId = 4 },
                new Doctor { Id = 8, Username = "marija", Password = "123", Name = "Marija", Surname = "Marijic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "marija@gmail.com", CityId = 1, SpecialitationId = 4 },
                new Doctor { Id = 9, Username = "tanja", Password = "123", Name = "Tanja", Surname = "Tankosic", Jmbg = "13316712312312", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3), ContactNumber = "06345111144", EMail = "tanja@gmail.com", CityId = 1, SpecialitationId = 5 }
            );

            modelBuilder.Entity<SystemAdministrator>().HasData(
               new SystemAdministrator { Id = 1, Username = "admin1", Password = "admin1", Name = "Vladislav", Surname = "Petkovic", Jmbg = "12312316712345", DateOfBirth = new DateTime(1998, 1, 1, 3, 3, 3), ContactNumber = "063775356", EMail = "vladislav@gmail.com", CityId = 1, Role = "Admin" },
               new SystemAdministrator { Id = 2, Username = "admin2", Password = "admin2", Name = "Dusan", Surname = "Vasiljev", Jmbg = "12312316712345", DateOfBirth = new DateTime(1998, 1, 1, 3, 3, 3), ContactNumber = "063775356", EMail = "dusan@gmail.com", CityId = 1, Role = "Admin" }
           );

            modelBuilder.Entity<Secretary>().HasData(
                new Secretary { Id = 1, Username = "sekretar1", Password = "123", Name = "Milica", Surname = "Carica", Jmbg = "12312316712345", DateOfBirth = new DateTime(1998, 1, 1, 3, 3, 3), ContactNumber = "063775356", EMail = "milica@gmail.com", CityId = 1 }
            );

            modelBuilder.Entity<Manager>().HasData(
                new Manager { Id = 1, Username = "manager1", Password = "123", Name = "Darja", Surname = "Rusedski", Jmbg = "12317316712344", DateOfBirth = new DateTime(1992, 1, 10, 3, 30, 0), ContactNumber = "063555156", EMail = "darja@gmail.com", CityId = 1 }
                );


            modelBuilder.Entity<Specialitation>().HasData(
                new Specialitation { Id = 1, SpecialitationForDoctor = "Lekar opste prakse" },
                new Specialitation { Id = 2, SpecialitationForDoctor = "Ortoped" },
                new Specialitation { Id = 3, SpecialitationForDoctor = "Kardiolog" },
                new Specialitation { Id = 4, SpecialitationForDoctor = "Dermatolog" },
                new Specialitation { Id = 5, SpecialitationForDoctor = "Endokrinolog" }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Beograd", Address = "Brace Jerkovic 1", CountryId = 1 },
                new City { Id = 2, Name = "Novi Sad", Address = "Bulevar Cara Lazara 1", CountryId = 1 }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Srbija" }
            );

          

            }
        }
    }
    


