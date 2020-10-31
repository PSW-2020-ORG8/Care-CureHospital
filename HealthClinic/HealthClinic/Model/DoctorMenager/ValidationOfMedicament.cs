// File:    ValidationOfMedicament.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 01:56:34
// Purpose: Definition of Class ValidationOfMedicament

using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
namespace Model.DoctorMenager
{
    public class ValidationOfMedicament : IIdentifiable<int>
    {
        private int id;
        private bool approved;
        private Medicament medicament;
        private Model.AllActors.Doctor doctor;
        private FeedbackOfValidation feedbackOfValidation;

        public bool Approved { get => approved; set => approved = value; }
        public Medicament Medicament { get => medicament; set => medicament = value; }
        public FeedbackOfValidation FeedbackOfValidation { get => feedbackOfValidation; set => feedbackOfValidation = value; }
        public Model.AllActors.Doctor Doctor { get => doctor; set => doctor = value; }

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
            this.doctor = doctor;
        }


        public ValidationOfMedicament(bool approved, Medicament medicament, FeedbackOfValidation feedbackOfValidation, Model.AllActors.Doctor doctor)
        {
            this.Approved = approved;
            this.Medicament = medicament;
            this.FeedbackOfValidation = feedbackOfValidation;
            this.doctor = doctor;
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