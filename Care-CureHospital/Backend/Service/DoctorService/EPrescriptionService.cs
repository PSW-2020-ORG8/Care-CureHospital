using Backend.Model.PatientDoctor;
using Backend.Repository.DoctorRepository;
using Backend.Repository.ExaminationSurgeryRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.DoctorService
{
    public class EPrescriptionService : IService<EPrescription, int>
    {
        public IEPrescriptionRepository eprescriptionRepository;

        public static object Assert { get; set; }

        public EPrescriptionService(IEPrescriptionRepository eprescriptionRepository)
        {
            this.eprescriptionRepository = eprescriptionRepository;
        }

        public EPrescription AddEntity(EPrescription entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(EPrescription entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EPrescription> GetAllEntities()
        {
            return eprescriptionRepository.GetAllEntities();
        }

        public EPrescription GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<EPrescription> GetPrescriptionsForPatient(int patientID)
        {
            List<EPrescription> prescriptionsForPatient = new List<EPrescription>();
            foreach (EPrescription prescription in eprescriptionRepository.GetAllEntities().ToList())
            {
                if (prescription.MedicalExamination.PatientId == patientID)
                {
                    prescriptionsForPatient.Add(prescription);
                }
            }
            return prescriptionsForPatient;
        }

        public List<EPrescription> FindPrescriptionsForDateParameter(int patientID, string publishingDate)
        {
            List<EPrescription> searchResult = new List<EPrescription>();
            foreach (EPrescription prescription in GetPrescriptionsForPatient(patientID))
            {
                if ((prescription.PublishingDate.ToString("yyyy-MM-dd").Equals(publishingDate)))
                {
                    searchResult.Add(prescription);
                }
            }
            return searchResult;
        }

        public void UpdateEntity(EPrescription entity)
        {
            throw new NotImplementedException();
        }

        public EPrescription GetEPrescriptionForPatient(int patientID)
        {
            return eprescriptionRepository.GetAllEntities().ToList().Find(EPrescription => EPrescription.MedicalExamination.PatientId == patientID);
        }
    }
}
