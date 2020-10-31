using HealthClinic.View.ViewModel;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class SecretaryConverter : AbstractConverter
    {
        public static ViewSecretary ConvertSecretaryToSecretaryView(Secretary secretary)
        {
            return new ViewSecretary
            {
                Id = secretary.GetId(),
                Name = secretary.Name,
                Surname = secretary.Surname,
                Jmbg = secretary.Jmbg,
                DateOfBirthday = secretary.DateOfBirth,
                City = secretary.City.Name,
                Address = secretary.City.Adress,
                Country = secretary.City.Country.Name,
                PhoneNumber = secretary.ContactNumber,
                EmailAddress = secretary.EMail,
                Username = secretary.UserName,
                Password = secretary.Password
            };
        }

        public static IList<ViewSecretary> ConvertSecretaryListToSecretaryViewList(IList<Secretary> secretaries)
            => ConvertEntityListToViewList(secretaries, ConvertSecretaryToSecretaryView);
    }
}
