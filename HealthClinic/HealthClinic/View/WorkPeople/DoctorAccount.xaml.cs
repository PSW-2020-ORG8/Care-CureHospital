using HealthClinic.View.ViewModel;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for DoctorAccount.xaml
    /// </summary>
    public partial class DoctorAccount : Window
    {
        public DoctorAccount(ViewDoctor doctor)
        {
            InitializeComponent();
            LabelName.Content = doctor.Name;
            LabelSurname.Content = doctor.Surname;
            LabelJmbg.Content = doctor.Jmbg;
            LabelDateOfBirthday.Content = doctor.DateOfBirthday;
            LabelCity.Content = doctor.City;
            LabelAddress.Content = doctor.Address;
            LabelCountry.Content = doctor.Country;
            LabelEmailAddress.Content = doctor.EmailAddress;
            LabelMobilePhone.Content = doctor.PhoneNumber;
            LabelVocation.Content = doctor.Spetialitation;
            LabelUsername.Content = doctor.Username;
            LabelPassword.Content = doctor.Password;
        }

        private void Button_Click_URedu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
