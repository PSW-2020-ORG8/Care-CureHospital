using FeedbackMicroservice.Domain;
using System.Collections.Generic;


namespace FeedbackMicroservice.Dto
{
    public class DoctorResultDto
    {
        public Doctor Doctor { get; set; }

        public List<QuestionResultDto> QuestionResults { get; set; }

        public DoctorResultDto() { }

        public DoctorResultDto(Doctor doctor, List<QuestionResultDto> questionResults)
        {
            Doctor = doctor;
            QuestionResults = questionResults;
        }
    }
}
