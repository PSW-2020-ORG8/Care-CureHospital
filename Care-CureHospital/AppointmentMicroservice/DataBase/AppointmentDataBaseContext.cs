using AppointmentMicroservice.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace AppointmentMicroservice.DataBase
{
    public class AppointmentDataBaseContext : DbContext
    {
        public DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<InventaryRoom> InventaryRoom { get; set; }
        public DbSet<TypeOfRoom> TypesOfRoom { get; set; }
        public DbSet<DoctorWorkDay> DoctorWorkDays { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
     
        public AppointmentDataBaseContext() : base() { }
        public AppointmentDataBaseContext(DbContextOptions<AppointmentDataBaseContext> options) : base(options) { }

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
         
            modelBuilder.Entity<Room>().HasData(
                  new Room { Id = 1, RoomId = "101", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "101", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 2, RoomId = "201", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "201", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 3, RoomId = "301", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "301", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 4, RoomId = "Room 1", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R1", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 5, RoomId = "Room 2", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R2", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 6, RoomId = "Room 3", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R3", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 7, RoomId = "Room 4", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R4", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 8, RoomId = "Room 5", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R5", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 9, RoomId = "Room 6", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R6", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 10, RoomId = "Doctor office 3", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "Dr3", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 11, RoomId = "Doctor office 4", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr4", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 12, RoomId = "Doctor office 1", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr1A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 13, RoomId = "Doctor office 2", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr2A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 14, RoomId = "Doctor office 1", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr1B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 15, RoomId = "Doctor office 2", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr2B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" },
                 new Room { Id = 16, RoomId = "Surgery room 1", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr1A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 17, RoomId = "Surgery room 2", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr2A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 18, RoomId = "Surgery room 3", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr3A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 19, RoomId = "Surgery room 1", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr1B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 20, RoomId = "Surgery room 2", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr2B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 21, RoomId = "Surgery room 3", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr3B", NameOfClinic = "B", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 22, RoomId = "Radiology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "RadA", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 23, RoomId = "Radiology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "RadB", NameOfClinic = "B", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 24, RoomId = "Cardiology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Card", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 25, RoomId = "Patology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Pat", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 26, RoomId = "Neurology", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Neur", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 27, RoomId = "Pyshiatric", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Psyc", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 28, RoomId = "Hospital A", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "HospitalA", NameOfClinic = "A", NumberOfFloor = "", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 29, RoomId = "Hospital B", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "HospitalB", NameOfClinic = "A", NumberOfFloor = "", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 30, RoomId = "Pharmacy", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "PhA", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" },
                 new Room { Id = 31, RoomId = "Pharmacy", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "PhB", NameOfClinic = "B", NumberOfFloor = "", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" }


             );

            modelBuilder.Entity<InventaryRoom>().HasData(
               new InventaryRoom { Id = 1, Name = "Stolovi", Quantity = 1, RoomId = 1 },
               new InventaryRoom { Id = 2, Name = "Stolice", Quantity = 1, RoomId = 1 },
               new InventaryRoom { Id = 3, Name = "Kreveti", Quantity = 1, RoomId = 2 }
           );

            modelBuilder.Entity<TypeOfRoom>().HasData(
                new TypeOfRoom { Id = 1, NameOfType = "Soba za preglede" },
                new TypeOfRoom { Id = 2, NameOfType = "Soba za operacije" },
                new TypeOfRoom { Id = 3, NameOfType = "Soba za lezanje" },
                new TypeOfRoom { Id = 4, NameOfType = "Ostale prostorije" }
            );

           

            modelBuilder.Entity<DoctorWorkDay>().HasData(
                new DoctorWorkDay { Id = 1, DoctorId = 1, Date = new DateTime(2020, 12, 20), RoomId = 1 },
                new DoctorWorkDay { Id = 2, DoctorId = 2, Date = new DateTime(2020, 12, 18), RoomId = 2 },
                new DoctorWorkDay { Id = 3, DoctorId = 3, Date = new DateTime(2020, 12, 25), RoomId = 2 },
                new DoctorWorkDay { Id = 4, DoctorId = 4, Date = new DateTime(2020, 12, 20), RoomId = 3 },
                new DoctorWorkDay { Id = 5, DoctorId = 2, Date = new DateTime(2020, 12, 21), RoomId = 3 },
                new DoctorWorkDay { Id = 6, DoctorId = 9, Date = new DateTime(2020, 11, 21), RoomId = 1 },
                new DoctorWorkDay { Id = 7, DoctorId = 8, Date = new DateTime(2020, 11, 23), RoomId = 2 },
                new DoctorWorkDay { Id = 8, DoctorId = 7, Date = new DateTime(2020, 11, 28), RoomId = 2 },
                new DoctorWorkDay { Id = 9, DoctorId = 6, Date = new DateTime(2020, 11, 29), RoomId = 3 },
                new DoctorWorkDay { Id = 10, DoctorId = 5, Date = new DateTime(2020, 11, 30), RoomId = 3 },
                 new DoctorWorkDay { Id = 11, DoctorId = 1, Date = new DateTime(2020, 12, 24), RoomId = 10 },
                new DoctorWorkDay { Id = 12, DoctorId = 2, Date = new DateTime(2020, 12, 22), RoomId = 11 },
                new DoctorWorkDay { Id = 13, DoctorId = 1, Date = new DateTime(2020, 12, 28), RoomId = 3 },
                new DoctorWorkDay { Id = 14, DoctorId = 1, Date = new DateTime(2021, 4, 4), RoomId = 1 }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 20, 8, 0, 0), EndTime = new DateTime(2020, 12, 20, 8, 30, 0), DoctorWorkDayId = 1, MedicalExaminationId = 1 },
                new Appointment { Id = 2, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 18, 8, 30, 0), EndTime = new DateTime(2020, 12, 18, 9, 0, 0), DoctorWorkDayId = 2, MedicalExaminationId = 2 },
                new Appointment { Id = 3, Canceled = true, CancellationDate = new DateTime(2020, 12, 22, 8, 30, 0), StartTime = new DateTime(2020, 12, 25, 8, 30, 0), EndTime = new DateTime(2020, 12, 25, 9, 0, 0), DoctorWorkDayId = 3, MedicalExaminationId = 4 },
                new Appointment { Id = 4, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 20, 8, 30, 0), EndTime = new DateTime(2020, 12, 20, 9, 0, 0), DoctorWorkDayId = 4, MedicalExaminationId = 6 },
                new Appointment { Id = 5, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 10, 12, 00, 0), EndTime = new DateTime(2020, 12, 10, 12, 30, 0), DoctorWorkDayId = 4, MedicalExaminationId = 4 },
                new Appointment { Id = 6, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 09, 15, 30, 0), EndTime = new DateTime(2020, 12, 09, 16, 00, 0), DoctorWorkDayId = 4, MedicalExaminationId = 2 },
                new Appointment { Id = 7, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 18, 15, 30, 0), EndTime = new DateTime(2020, 12, 18, 16, 0, 0), DoctorWorkDayId = 2, MedicalExaminationId = 5 },
                new Appointment { Id = 8, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2020, 12, 21, 8, 30, 0), EndTime = new DateTime(2020, 12, 21, 9, 0, 0), DoctorWorkDayId = 5, MedicalExaminationId = 3 },
                new Appointment { Id = 9, Canceled = true, CancellationDate = new DateTime(2020, 11, 18, 8, 0, 0), StartTime = new DateTime(2020, 11, 21, 8, 0, 0), EndTime = new DateTime(2020, 11, 21, 8, 30, 0), DoctorWorkDayId = 6, MedicalExaminationId = 7 },
                new Appointment { Id = 10, Canceled = true, CancellationDate = new DateTime(2020, 11, 20, 8, 0, 0), StartTime = new DateTime(2020, 11, 23, 8, 0, 0), EndTime = new DateTime(2020, 11, 23, 8, 30, 0), DoctorWorkDayId = 7, MedicalExaminationId = 8 },
                new Appointment { Id = 11, Canceled = true, CancellationDate = new DateTime(2020, 11, 25, 8, 0, 0), StartTime = new DateTime(2020, 11, 28, 8, 0, 0), EndTime = new DateTime(2020, 11, 28, 8, 30, 0), DoctorWorkDayId = 8, MedicalExaminationId = 9 },
                new Appointment { Id = 12, Canceled = true, CancellationDate = new DateTime(2020, 11, 26, 8, 0, 0), StartTime = new DateTime(2020, 11, 29, 8, 0, 0), EndTime = new DateTime(2020, 11, 29, 8, 30, 0), DoctorWorkDayId = 9, MedicalExaminationId = 10 },
                new Appointment { Id = 13, Canceled = true, CancellationDate = new DateTime(2020, 11, 27, 8, 0, 0), StartTime = new DateTime(2020, 11, 30, 8, 0, 0), EndTime = new DateTime(2020, 11, 30, 8, 30, 0), DoctorWorkDayId = 10, MedicalExaminationId = 11 },
                new Appointment { Id = 14, Canceled = true, CancellationDate = new DateTime(2020, 11, 18, 8, 0, 0), StartTime = new DateTime(2020, 11, 21, 9, 0, 0), EndTime = new DateTime(2020, 11, 21, 9, 30, 0), DoctorWorkDayId = 6, MedicalExaminationId = 12 },
                new Appointment { Id = 15, Canceled = false, CancellationDate = new DateTime(), StartTime = new DateTime(2021, 4, 4, 9, 0, 0), EndTime = new DateTime(2021, 4, 4, 9, 30, 0), DoctorWorkDayId = 14, MedicalExaminationId = 12 }
            );

            modelBuilder.Entity<MedicalExamination>().HasData(
                new MedicalExamination { Id = 1, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 1, DoctorId = 1, PatientId = 2 },
                new MedicalExamination { Id = 2, SurveyFilled = false, ShortDescription = "Pacijent je imao glavobolju", RoomId = 2, DoctorId = 2, PatientId = 1 },
                new MedicalExamination { Id = 3, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 2, PatientId = 1 },
                new MedicalExamination { Id = 4, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 3, PatientId = 1 },
                new MedicalExamination { Id = 5, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 2, PatientId = 3 },
                new MedicalExamination { Id = 6, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 4, PatientId = 1 },
                new MedicalExamination { Id = 7, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 1, DoctorId = 9, PatientId = 5 },
                new MedicalExamination { Id = 8, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 8, PatientId = 5 },
                new MedicalExamination { Id = 9, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 2, DoctorId = 7, PatientId = 5 },
                new MedicalExamination { Id = 10, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 6, PatientId = 6 },
                new MedicalExamination { Id = 11, SurveyFilled = false, ShortDescription = "Sve je bilo u redu na pregledu", RoomId = 3, DoctorId = 5, PatientId = 6 },
                new MedicalExamination { Id = 12, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 1, DoctorId = 9, PatientId = 1 },
                new MedicalExamination { Id = 13, SurveyFilled = false, ShortDescription = "Pacijenta je boleo stomak", RoomId = 1, DoctorId = 1, PatientId = 1 }
            );
        }
    }
}
