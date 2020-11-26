using Backend.Model.PatientDoctor;
using Backend.Repository.ExaminationSurgeryRepository;
using Model.DoctorMenager;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class PrescriptionService : IService<Prescription, int>
    {
        public IPrescriptionRepository prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        public List<Prescription> GetPrescriptionsForPatient(int patientID)
        {
            List<Prescription> prescriptionsForPatient = new List<Prescription>();
            foreach (Prescription prescription in prescriptionRepository.GetAllEntities().ToList())
            {
                if (prescription.MedicalExamination.PatientId == patientID)
                {
                    prescriptionsForPatient.Add(prescription);
                }
            }
            return prescriptionsForPatient;
        }

        public List<Prescription> FindPrescriptionsForCommentParameter(int patientID, string comment)
        {
            List<Prescription> searchResult = new List<Prescription>();
            foreach (Prescription prescription in GetPrescriptionsForPatient(patientID))
            {
                if ((prescription.Comment.ToString().Contains(comment)))
                {
                    searchResult.Add(prescription);
                }
            }
            return searchResult;
        }

        public List<Prescription> FindPrescriptionsForDateParameter(int patientID, string publishingDate)
        {
            List<Prescription> searchResult = new List<Prescription>();
            foreach (Prescription prescription in GetPrescriptionsForPatient(patientID))
            {
                if ((prescription.PublishingDate.ToString("yyyy-MM-dd").Equals(publishingDate)))
                {
                    searchResult.Add(prescription);
                }
            }
            return searchResult;
        }

        public List<Prescription> FindPrescriptionsForDoctorParameter(int patientID, string doctorFullName)
        {
            List<Prescription> searchResult = new List<Prescription>();
            foreach (Prescription prescription in GetPrescriptionsForPatient(patientID))
            {
                if ((prescription.MedicalExamination.Doctor.Name.ToString() + " " + prescription.MedicalExamination.Doctor.Surname.ToString()).Equals(doctorFullName) ||
                    doctorFullName.Contains(prescription.MedicalExamination.Doctor.Name.ToString()) || doctorFullName.Contains(prescription.MedicalExamination.Doctor.Surname.ToString()))
                {
                    searchResult.Add(prescription);
                }
            }
            return searchResult;
        }

        public List<Prescription> FindPrescriptionsForMedicamentsParameter(int patientID, string medicaments)
        {
            List<Prescription> searchResult = new List<Prescription>();
            foreach (Prescription prescription in GetPrescriptionsForPatient(patientID))
            {
                foreach (Medicament medicament in prescription.Medicaments)
                {
                    if (medicaments.ToString().Contains(medicament.Name.ToString()))
                    {
                        searchResult.Add(prescription);
                    }
                }
            }
            return searchResult;
        }

        public Prescription GetEntity(int id)
        {
            return prescriptionRepository.GetEntity(id);
        }

        public IEnumerable<Prescription> GetAllEntities()
        {
            return prescriptionRepository.GetAllEntities();
        }

        public Prescription AddEntity(Prescription entity)
        {
            return prescriptionRepository.AddEntity(entity);
        }

        public void UpdateEntity(Prescription entity)
        {
            prescriptionRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Prescription entity)
        {
            prescriptionRepository.DeleteEntity(entity);
        }
    }
}
