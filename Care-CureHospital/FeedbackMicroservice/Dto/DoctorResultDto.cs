using System.Collections.Generic;


namespace FeedbackMicroservice.Dto
{
    public class DoctorResultDto
    {
        public int DoctorId { get; set; }

        public List<QuestionResultDto> QuestionResults { get; set; }


        public DoctorResultDto() { }

        public DoctorResultDto(int doctorId, List<QuestionResultDto> questionResults)
        {
            DoctorId = doctorId;
            QuestionResults = questionResults;
        }
    }
}
