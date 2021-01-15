using UserMicroservice.Domain;
using UserMicroservice.Dto;

namespace UserMicroservice.Mapper
{
    public class DoctorMapper
    {

        public static DoctorDto DoctorToDoctorDto(Doctor doctor)
        {
            DoctorDto dto = new DoctorDto();
            dto.Id = doctor.Id;
            dto.Name = doctor.PersonalInfo.Name;
            dto.Surname = doctor.PersonalInfo.Surname;
            return dto;
        }
    }
}
