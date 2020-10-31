using Controller.UsersControlers;
using HealthClinic.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SecretaryAccount.xaml
    /// </summary>
    public partial class SecretaryAccount : Window
    {
        public SecretaryAccount(ViewSecretary secretary)
        {
            InitializeComponent();
            LabelName.Content = secretary.Name;
            LabelSurname.Content = secretary.Surname;
            LabelJmbg.Content = secretary.Jmbg;
            LabelDateOfBirthday.Content = secretary.DateOfBirthday;
            LabelCity.Content = secretary.City;
            LabelAddress.Content = secretary.Address;
            LabelCountry.Content = secretary.Country;
            LabelEmailAddress.Content = secretary.EmailAddress;
            LabelMobilePhone.Content = secretary.PhoneNumber;
            LabelUsername.Content = secretary.Username;
            LabelPassword.Content = secretary.Password;
        }

        private void Button_Click_URedu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
