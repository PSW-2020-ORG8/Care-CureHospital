using HealthClinic.View.ViewModel;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class ManagerConverter : AbstractConverter
    {
        public static ViewManager ConvertManagerToManagerView(Manager manager)
        {
            return new ViewManager
            {
                Id = manager.GetId(),
                Name = manager.Name,
                Surname = manager.Surname,
                Jmbg = manager.Jmbg,
                DateOfBirthday = manager.DateOfBirth,
                City = manager.City.Name,
                Address = manager.City.Adress,
                Country = manager.City.Country.Name,
                PhoneNumber = manager.ContactNumber,
                EmailAddress = manager.EMail,
                Username = manager.UserName,
                Password = manager.Password
            };
        }

        public static IList<ViewManager> ConvertManagerListToManagerViewList(IList<Manager> managers)
            => ConvertEntityListToViewList(managers, ConvertManagerToManagerView);
    }
}
