using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Dto;

namespace DocumentsMicroservice.Mapper
{
    public class MedicalExaminationReportMapper
    {
        public static MedicalExaminationReportDto MedicalExaminationReportToMedicalExaminationReportDto(MedicalExaminationReport medicalExaminationReport, MedicalExamination medicalExamination)
        {
            MedicalExaminationReportDto dto = new MedicalExaminationReportDto();
            dto.Id = medicalExaminationReport.Id;
            dto.Comment = medicalExaminationReport.Comment;
            dto.PublishingDate = medicalExaminationReport.PublishingDate.ToString("dd.MM.yyyy.");
            dto.Doctor = medicalExamination.Doctor.Name + " " + medicalExamination.Doctor.Surname;
            dto.Room = medicalExamination.Room.RoomId;
            return dto;
        }
    }
}
