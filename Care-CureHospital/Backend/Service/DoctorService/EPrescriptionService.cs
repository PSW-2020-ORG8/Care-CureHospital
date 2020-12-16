using Backend.Model.PatientDoctor;
using Backend.Repository.DoctorRepository;
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
        public void UpdateEntity(EPrescription entity)
        {
            throw new NotImplementedException();
        }

         public EPrescription GetEPrescriptionForPatient(int patientID)
         {
             return eprescriptionRepository.GetAllEntities().ToList().Find(ePrescription => ePrescription.PatientId == patientID);
         }

        public List<EPrescription> GetEPrescriptionsForPatient(int patientID)
        {
            List<EPrescription> eprescriptionsForPatient = new List<EPrescription>();
            foreach (EPrescription eprescription in eprescriptionRepository.GetAllEntities().ToList())
            {
                if (eprescription.PatientId == patientID)
                {
                    eprescriptionsForPatient.Add(eprescription);
                }
            }
            return eprescriptionsForPatient;
        }

        public List<EPrescription> FindEPrescriptionsForCommentParameter(int patientID, string comment)
        {
            List<EPrescription> searchResult = new List<EPrescription>();
            foreach (EPrescription eprescription in GetEPrescriptionsForPatient(patientID))
            {
                if ((eprescription.Comment.ToString().ToLower().Contains(comment.ToLower())))
                {
                    searchResult.Add(eprescription);
                }
            }
            return searchResult;
        }

        public List<EPrescription> FindEPrescriptionsForDateParameter(int patientID, string publishingDate)
        {
            List<EPrescription> searchResult = new List<EPrescription>();
            foreach (EPrescription eprescription in GetEPrescriptionsForPatient(patientID))
            {
                if ((eprescription.PublishingDate.ToString("yyyy-MM-dd").Equals(publishingDate)))
                {
                    searchResult.Add(eprescription);
                }
            }
            return searchResult;
        }
    }
}
