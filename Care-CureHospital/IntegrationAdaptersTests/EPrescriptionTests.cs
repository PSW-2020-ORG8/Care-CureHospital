using Backend.Model.PatientDoctor;
using Backend.Repository.DoctorRepository;
using Backend.Service.DoctorService;
using Model.AllActors;
using Model.Doctor;
using Model.DoctorMenager;
using Model.Term;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAdaptersTests
{
    public class EPrescriptionTests
    {

        [Fact]
        public void Find_()
        {
            EPrescriptionService ePrescriptionService = new EPrescriptionService(CreateStubRepository());

            EPrescription ePrescription = ePrescriptionService.GetEPrescriptionForPatient(1);

            Assert.NotNull(ePrescription);
        }



        private static IEPrescriptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IEPrescriptionRepository>();

            var eprescriptions = new List<EPrescription>();
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient(1));
            patients.Add(new Patient(2));
            List<Medicament> medicaments = new List<Medicament>();
            medicaments.Add(new Medicament("Brufen"));
            medicaments.Add(new Medicament("Paracetamol"));

            eprescriptions.Add(new EPrescription { Id = 1, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 08, 12, 10, 30, 0), MedicalExamination = new MedicalExamination(1, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Milan", "Petrovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)),Patients = patients, Medicaments = medicaments });
            eprescriptions.Add(new EPrescription { Id = 2, Comment = "Svakodnevno koristite prepisani lek", PublishingDate = new DateTime(2020, 12, 23, 10, 30, 0), MedicalExamination = new MedicalExamination(2, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Jovan", "Simic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Patients = patients, Medicaments = medicaments });
            eprescriptions.Add(new EPrescription { Id = 3, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 10, 05, 10, 30, 0), MedicalExamination = new MedicalExamination(3, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Milan", "Petrovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Patients = patients, Medicaments = medicaments });
            eprescriptions.Add(new EPrescription { Id = 4, Comment = "Ne preskacite konzumiranje leka", PublishingDate = new DateTime(2020, 11, 30, 10, 30, 0), MedicalExamination = new MedicalExamination(4, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Milan", "Petrovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Patients = patients, Medicaments = medicaments });
            eprescriptions.Add(new EPrescription { Id = 5, Comment = "Redovno koristite prepisane lekove", PublishingDate = new DateTime(2020, 10, 05, 10, 30, 0), MedicalExamination = new MedicalExamination(5, false, "Opis", 1, 2, 1, new Room(), new Doctor("pera", "123", "Jovan", "Simic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1)), Patients = patients, Medicaments = medicaments });

            stubRepository.Setup(prescriptionRepository => prescriptionRepository.GetAllEntities()).Returns(eprescriptions);

            return stubRepository.Object;
        }

    }
}
