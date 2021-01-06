using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Dto;


namespace FeedbackMicroservice.Mapper
{
    public class PatientFeedbackMapper
    {
        public static PatientFeedback PatientFeedbackDtoToPatientFeedback(PatientFeedbackDto dto)
        {
            PatientFeedback patientFeedback = new PatientFeedback();

            patientFeedback.IsForPublishing = dto.IsForPublishing;
            patientFeedback.IsPublished = dto.IsPublished;
            patientFeedback.IsAnonymous = dto.IsAnonymous;
            patientFeedback.PatientId = dto.PatientId;
            patientFeedback.Text = dto.Text;

            return patientFeedback;
        }

        public static PatientFeedbackDto PatientFeedbackToPatientFeedbackDto(PatientFeedback patientFeedback, Patient patient)
        {
            PatientFeedbackDto dto = new PatientFeedbackDto();
            dto.Id = patientFeedback.Id;
            dto.IsForPublishing = patientFeedback.IsForPublishing;
            dto.IsPublished = patientFeedback.IsPublished;
            dto.IsAnonymous = patientFeedback.IsAnonymous;
            dto.PatientId = patientFeedback.PatientId;
            dto.Patient = patient.Name + " " + patient.Surname;
            dto.PublishingDate = patientFeedback.PublishingDate.ToString("dd.MM.yyyy. HH:mm");
            dto.Text = patientFeedback.Text;

            return dto;
        }
    }
}
