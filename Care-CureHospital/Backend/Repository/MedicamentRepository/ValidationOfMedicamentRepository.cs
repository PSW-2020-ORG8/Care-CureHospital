// File:    ValidationOfMedicamentRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 02:04:51
// Purpose: Definition of Class ValidationOfMedicamentRepository

using Model.AllActors;
using Model.DoctorMenager;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.MedicamentRepository
{
    public class ValidationOfMedicamentRepository : CSVRepository<ValidationOfMedicament, int>, IValidationOfMedicamentRepository
    {
        private const string VALIDATIONOFMEDICAMENT_FILE = "../../Resources/Data/validationofmedicament.csv";
        private static ValidationOfMedicamentRepository instance;

        public static ValidationOfMedicamentRepository Instance()
        {
            if (instance == null)
            {
                instance = new ValidationOfMedicamentRepository(
               new CSVStream<ValidationOfMedicament>(VALIDATIONOFMEDICAMENT_FILE, new ValidationMedicamentCSVConverter(",")),
               new IntSequencer());
            }
            return instance;
        }

        public ValidationOfMedicamentRepository(ICSVStream<ValidationOfMedicament> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

        public List<ValidationOfMedicament> GetMedicamentsOnValidationForDoctor(Doctor doctor)
        {
            List<ValidationOfMedicament> medicamentsOnValidation = new List<ValidationOfMedicament>();
            foreach (ValidationOfMedicament validationOfMedicament in GetAllEntities())
                if (validationOfMedicament.Doctor.GetId() == doctor.GetId())
                    medicamentsOnValidation.Add(validationOfMedicament);
            return medicamentsOnValidation;
        }
    }
}