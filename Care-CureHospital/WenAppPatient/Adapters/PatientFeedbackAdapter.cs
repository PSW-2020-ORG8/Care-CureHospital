using Backend.Model.BlogAndNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WenAppPatient.Dto;

namespace WenAppPatient.Adapters
{
    public class PatientFeedbackAdapter
    {
        public static PatientFeedback PatientFeedbackDtoToPatientFeedback(PatientFeedbackDto dto)
        {
            PatientFeedback patientFeedback = new PatientFeedback();

            patientFeedback.IsForPublishing = dto.isForPublishing;
            patientFeedback.IsPublished = dto.isPublished;
            patientFeedback.IsAnonymous = dto.isAnonymous;
            patientFeedback.Patient = dto.patient;
            patientFeedback.PublishingDate = dto.publishingDate;
            patientFeedback.Text = dto.text;

            return patientFeedback;
        }

        public static PatientFeedbackDto PatientFeedbackToPatientFeedbackDto(PatientFeedback patientFeedback)
        {
            PatientFeedbackDto dto = new PatientFeedbackDto();
            dto.isForPublishing = patientFeedback.IsForPublishing;
            dto.isPublished = patientFeedback.IsPublished;
            dto.isAnonymous = patientFeedback.IsAnonymous;
            dto.patient = patientFeedback.Patient;
            dto.publishingDate = patientFeedback.PublishingDate;
            dto.text = patientFeedback.Text;

            return dto;
        }
    }
}
