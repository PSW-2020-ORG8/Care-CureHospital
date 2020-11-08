﻿using Backend.Dto;
using Backend.Model.BlogAndNotification;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Adapters
{
    public class PatientFeedbackAdapter
    {
        public static PatientFeedback PatientFeedbackDtoToPatientFeedback(PatientFeedbackDto dto, Patient patient)
        {
            PatientFeedback patientFeedback = new PatientFeedback();

            patientFeedback.IsForPublishing = dto.IsForPublishing;
            patientFeedback.IsPublished = dto.IsPublished;
            patientFeedback.IsAnonymous = dto.IsAnonymous;
            patientFeedback.PatientID = dto.PatientId;
            patientFeedback.Patient = null;
            patientFeedback.PublishingDate = dto.PublishingDate;
            patientFeedback.Text = dto.Text;

            return patientFeedback;
        }

        public static PatientFeedbackDto PatientFeedbackToPatientFeedbackDto(PatientFeedback patientFeedback)
        {
            PatientFeedbackDto dto = new PatientFeedbackDto();
            dto.IsForPublishing = patientFeedback.IsForPublishing;
            dto.IsPublished = patientFeedback.IsPublished;
            dto.IsAnonymous = patientFeedback.IsAnonymous;
            dto.PatientId = patientFeedback.PatientID;
            dto.Patient = patientFeedback.Patient.Name + " " + patientFeedback.Patient.Surname;
            dto.PublishingDate = patientFeedback.PublishingDate;
            dto.Text = patientFeedback.Text;

            return dto;
        }
    }
}