using Controller.UsersControlers;
using HealthClinic.View.Converter;
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

namespace HealthClinic.View.WorkPeople
{
    /// <summary>
    /// Interaction logic for CreateSecretaryAccount.xaml
    /// </summary>
    public partial class CreateSecretaryAccount : Window
    {
        private readonly UserController userController;

        public CreateSecretaryAccount()
        {
            InitializeComponent();
            InputName.Focus();
            InputName.SelectAll();
            var app = Application.Current as App;
            userController = app.UserController;
        }

        private void Button_Click_Potvrdi(object sender, RoutedEventArgs e)
        {
            if (InputName.Text.Equals("") || InputSurname.Text.Equals("") || InputJmbg.Text.Equals("") || InputDateOfBirthday.Equals("") ||
                InputAddress.Text.Equals("") || InputCity.Text.Equals("") || InputCountry.Text.Equals("") || InputMobilePhone.Text.Equals("") ||
                InputEmailAddress.Text.Equals("") || InputUsername.Text.Equals("") || InputPassword.Text.Equals(""))
            {
                MessageBox.Show("Morate popuniti sva polja", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (userController.GetUserByUsername(InputUsername.Text) == null)
            {
                SecretaryAccounts.SecretaryView.Add(SecretaryConverter.ConvertSecretaryToSecretaryView(
                (Secretary)userController.AddEntity(new Secretary(InputUsername.Text, InputPassword.Text, InputName.Text, InputSurname.Text, InputJmbg.Text,
                DateTime.Parse(InputDateOfBirthday.Text), InputMobilePhone.Text, InputEmailAddress.Text,
                new City(InputCity.Text, InputCity.Text, new Country(InputCountry.Text))))));

                this.Close();
                MessageBox.Show("Uspešno ste kreirali nalog sekretaru", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MessageBox.Show("Korisničko ime koje ste uneli već postoji", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
