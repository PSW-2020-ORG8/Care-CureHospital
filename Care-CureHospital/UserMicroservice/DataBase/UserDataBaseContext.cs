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
                new Patient { Id = 1, PersonalInfo = { Name = "Petar", Surname = "Petrovic", ParentName = "Zika", Jmbg = "13312312312312", Gender = Gender.Male, IdentityCard = "123123123", DateOfBirth = new DateTime(2000, 1, 1, 3, 3, 3) }, MedicalInfo = { HealthInsuranceCard = "32312312312", BloodGroup = BloodGroup.AbMinus }, ContactInfo = { ContactNumber = "063554533", EMail = "pera@gmail.com" }, AccountInfo = { Username = "pera", Password = "123" }, PatientStatus = { Blocked = false, Malicious = false }, CityId = 1 },
                new Patient { Id = 2, PersonalInfo = { Name = "Zika", Surname = "Zikic", ParentName = "Pera", Jmbg = "12342312312312",  Gender = Gender.Male, IdentityCard = "124123123", DateOfBirth = new DateTime(2001, 1, 1, 3, 3, 3), }, MedicalInfo = { HealthInsuranceCard = "712312312312", BloodGroup = BloodGroup.AbMinus }, ContactInfo = { ContactNumber = "0635235333", EMail = "zika@gmail.com" }, AccountInfo = { Username = "zika", Password = "123" }, PatientStatus = { Blocked = false, Malicious = false }, CityId = 2 },
                new Patient { Id = 3, PersonalInfo = { Name = "Mica", Surname = "Micic", ParentName = "Jelena", Jmbg = "12312512312312", Gender = Gender.Male, IdentityCard = "163123123", DateOfBirth = new DateTime(2002, 1, 1, 3, 3, 3) }, MedicalInfo = { HealthInsuranceCard = "62312312312", BloodGroup = BloodGroup.Unknown }, ContactInfo = { ContactNumber = "0635557673", EMail = "mica@gmail.com" }, AccountInfo = { Username = "mica", Password = "123" }, PatientStatus = { Blocked = false, Malicious = false }, CityId = 1 },
                new Patient { Id = 4, PersonalInfo = { Name = "Luna", Surname = "Lunic", ParentName = "Jovan", Jmbg = "12312316712312", Gender = Gender.Female, IdentityCard = "127123123", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3) }, MedicalInfo = { HealthInsuranceCard = "52312312312", BloodGroup = BloodGroup.AbMinus }, ContactInfo = { ContactNumber = "063555356", EMail = "luna@gmail.com" }, AccountInfo = { Username = "luna", Password = "123" }, PatientStatus = { Blocked = false, Malicious = false }, CityId = 2 },
                new Patient { Id = 5, PersonalInfo = { Name = "Ivan", Surname = "Ivanovic", ParentName = "Luka", Jmbg = "12344316712312", Gender = Gender.Male, IdentityCard = "127199123", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3) }, MedicalInfo = { HealthInsuranceCard = "52318812312", BloodGroup = BloodGroup.AbMinus }, ContactInfo = { ContactNumber = "063775356", EMail = "ivan@gmail.com" }, AccountInfo = { Username = "ivan", Password = "123" }, PatientStatus = { Blocked = false, Malicious = true }, CityId = 2 },
                new Patient { Id = 6, PersonalInfo = { Name = "Marko", Surname = "Markovic", ParentName = "Jovan", Jmbg = "12312316712344", Gender = Gender.Male, IdentityCard = "127123333", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3) }, MedicalInfo = { HealthInsuranceCard = "52312312311", BloodGroup = BloodGroup.AbMinus }, ContactInfo = { ContactNumber = "063555312", EMail = "marko@gmail.com" }, AccountInfo = { Username = "marko", Password = "123" }, PatientStatus = { Blocked = false, Malicious = true }, CityId = 2 }
            );


            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, AccountInfo = { Username = "milan", Password = "123" }, PersonalInfo = { Name = "Milan", Surname = "Petrovic", ParentName = "Zika", Jmbg = "13312312312312", Gender = Gender.Male, IdentityCard = "222123123", DateOfBirth = new DateTime(2000, 1, 1, 3, 3, 3) } , ContactInfo = { ContactNumber = "06345111144", EMail = "milan@gmail.com" }, CityId = 2, SpecialitationId = 1 },
                new Doctor { Id = 2, AccountInfo = { Username = "aca", Password = "123" }, PersonalInfo = { Name = "Aleksandar", Surname = "Aleksic", ParentName = "Mika", Jmbg = "13212312312312", Gender = Gender.Male, IdentityCard = "333123123", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "06345111144", EMail = "aca@gmail.com" }, CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 3, AccountInfo = { Username = "jovan", Password = "123" }, PersonalInfo = { Name = "Jovan", Surname = "Jovic", ParentName = "Pera", Jmbg = "13312367312312", Gender = Gender.Male, IdentityCard = "444123123", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "06345111144", EMail = "jovan@gmail.com" }, CityId = 2, SpecialitationId = 2 },
                new Doctor { Id = 4, AccountInfo = { Username = "nikola", Password = "123" }, PersonalInfo = { Name = "Nikola", Surname = "Nikic", ParentName = "Rade", Jmbg = "13316712312312", Gender = Gender.Male, IdentityCard = "555123123", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "06345111144", EMail = "nikola@gmail.com" }, CityId = 1, SpecialitationId = 1 },
                new Doctor { Id = 5, AccountInfo = { Username = "mihajlo", Password = "123" }, PersonalInfo = { Name = "Mihajlo", Surname = "Mihajlovic", ParentName = "Mirko", Jmbg = "13312367312312", Gender = Gender.Male, IdentityCard = "666123123", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "06345111144", EMail = "mihajlo@gmail.com" }, CityId = 2, SpecialitationId = 3 },
                new Doctor { Id = 6, AccountInfo = { Username = "vuk", Password = "123" }, PersonalInfo = { Name = "Vuk", Surname = "Vukic", ParentName = "Zivko", Jmbg = "13316712312312", Gender = Gender.Male, IdentityCard = "777123123", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "06345111144", EMail = "vuk@gmail.com" }, CityId = 1, SpecialitationId = 3 },
                new Doctor { Id = 7, AccountInfo = { Username = "helena", Password = "123" }, PersonalInfo = { Name = "Helena", Surname = "Kostic", ParentName = "Janko", Jmbg = "13312367312312", Gender = Gender.Female, IdentityCard = "888123123", DateOfBirth = new DateTime(2005, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "06345111144", EMail = "helena@gmail.com" }, CityId = 2, SpecialitationId = 4 },
                new Doctor { Id = 8, AccountInfo = { Username = "marija", Password = "123" }, PersonalInfo = { Name = "Marija", Surname = "Marijic", ParentName = "Marko", Jmbg = "13316712312312", Gender = Gender.Female, IdentityCard = "999123123", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "06345111144", EMail = "marija@gmail.com" }, CityId = 1, SpecialitationId = 4 },
                new Doctor { Id = 9, AccountInfo = { Username = "tanja", Password = "123" }, PersonalInfo = { Name = "Tanja", Surname = "Tankosic", ParentName = "Milos", Jmbg = "13316712312312", Gender = Gender.Female, IdentityCard = "998123123", DateOfBirth = new DateTime(2004, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "06345111144", EMail = "tanja@gmail.com" }, CityId = 1, SpecialitationId = 5 }
            ) ;

            modelBuilder.Entity<SystemAdministrator>().HasData(
               new SystemAdministrator { Id = 1, AccountInfo = { Username = "admin1", Password = "admin1" }, PersonalInfo = { Name = "Vladislav", Surname = "Petkovic", ParentName = "Milos", Jmbg = "12312316712345", Gender = Gender.Male, IdentityCard = "111113123", DateOfBirth = new DateTime(1998, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "063775356", EMail = "vladislav@gmail.com" }, CityId = 1  },
               new SystemAdministrator { Id = 2, AccountInfo = { Username = "admin2", Password = "admin2" }, PersonalInfo = { Name = "Dusan", Surname = "Vasiljev", ParentName = "Milos", Jmbg = "12312316712345", Gender = Gender.Male, IdentityCard = "222223123", DateOfBirth = new DateTime(1998, 1, 1, 3, 3, 3) }, ContactInfo = { ContactNumber = "063775356", EMail = "dusan@gmail.com" }, CityId = 1  }
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
    


