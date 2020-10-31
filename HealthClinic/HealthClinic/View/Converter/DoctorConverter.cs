using HealthClinic.View.ViewModel;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class DoctorConverter : AbstractConverter
    {
        public static ViewDoctor ConvertDoctorToDoctorView(Doctor doctor)
        {
            return new ViewDoctor
            {
                Id = doctor.GetId(),
                Name = doctor.Name,
                Surname = doctor.Surname,
                Jmbg = doctor.Jmbg,
                DateOfBirthday = doctor.DateOfBirth,
                City = doctor.City.Name,
                Address = doctor.City.Adress,
                Country = doctor.City.Country.Name,
                PhoneNumber = doctor.ContactNumber,
                EmailAddress = doctor.EMail,
                Spetialitation = doctor.Specialitation.SpecialitationForDoctor,
                Username = doctor.UserName,
                Password = doctor.Password
            };
        }

        public static IList<ViewDoctor> ConvertDoctorListToDoctorViewList(IList<Doctor> doctors)
            => ConvertEntityListToViewList(doctors, ConvertDoctorToDoctorView);
    }
}
