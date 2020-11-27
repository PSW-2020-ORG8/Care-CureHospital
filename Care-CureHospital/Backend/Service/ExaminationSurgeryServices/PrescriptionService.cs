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

        public List<Prescription> FindPrescriptionsUsingAdvancedSearch(int patientId, Dictionary<string, string> searchParameters, List<string> logicOperators)
        {
            List<Prescription> currentResult = FindPrescriptionsBySearchParameter(patientId, searchParameters.Keys.ToList()[0], searchParameters.Values.ToList()[0]);
            for (int i = 1; i < searchParameters.Keys.Count; i++)
            {
                List<Prescription> nextResult = FindPrescriptionsBySearchParameter(patientId, searchParameters.Keys.ToList()[i], searchParameters.Values.ToList()[i]);
                currentResult = CalculateLogicalOperationResult(logicOperators[i - 1], currentResult, nextResult);
            }
            return currentResult;
        }

        public List<Prescription> FindPrescriptionsBySearchParameter(int patientId, string parameter, string parameterValue)
        {
            if (parameter.Equals("Doktoru"))
            {
                return FindPrescriptionsForDoctorParameter(patientId, parameterValue);
            }
            else if (parameter.Equals("Datumu"))
            {
                return FindPrescriptionsForDateParameter(patientId, parameterValue);
            }
            else if (parameter.Equals("Sadržaju"))
            {
                return FindPrescriptionsForCommentParameter(patientId, parameterValue);
            }
            else if (parameter.Equals("Lekovima"))
            {
                return FindPrescriptionsForMedicamentsParameter(patientId, parameterValue);
            }
            return null;
        }

        public List<Prescription> CalculateLogicalOperationResult(string logicOperator, List<Prescription> firstResult, List<Prescription> secondResult)
        {
            List<Prescription> result = new List<Prescription>();
            if (logicOperator.Equals("I"))
            {
                result = firstResult.Intersect(secondResult).ToList();
            }
            else if (logicOperator.Equals("ILI"))
            {
                result = firstResult.Union(secondResult).ToList();
            }
            return result;
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
