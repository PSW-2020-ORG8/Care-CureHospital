// File:    ValidationOfMedicament.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 01:56:34
// Purpose: Definition of Class ValidationOfMedicament

using HealthClinic.Repository;
using System;
using System.Collections.Generic;

namespace Model.DoctorMenager
{
    public class ValidationOfMedicament : IIdentifiable<int>
    {
        public int id { get; set; }
        public bool Approved { get; set; }
        public int medicamentID { get; set; }
        public int doctorID { get; set; }
        public int feedbackOfValidationID { get; set; }
        public virtual Medicament Medicament { get; set; }
        public virtual Model.AllActors.Doctor Doctor { get; set; }
        public virtual FeedbackOfValidation FeedbackOfValidation { get; set; }

        public ValidationOfMedicament(int id)
        {
            this.id = id;
        }

        public ValidationOfMedicament()
        {
        }

        public ValidationOfMedicament(int id, bool approved, Medicament medicament, FeedbackOfValidation feedbackOfValidation, Model.AllActors.Doctor doctor)
        {
            this.Approved = approved;
            this.id = id;
            this.Medicament = medicament;
            this.FeedbackOfValidation = feedbackOfValidation;
            this.Doctor = doctor;
        }


        public ValidationOfMedicament(bool approved, Medicament medicament, FeedbackOfValidation feedbackOfValidation, Model.AllActors.Doctor doctor)
        {
            this.Approved = approved;
            this.Medicament = medicament;
            this.FeedbackOfValidation = feedbackOfValidation;
            this.Doctor = doctor;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
    }
}