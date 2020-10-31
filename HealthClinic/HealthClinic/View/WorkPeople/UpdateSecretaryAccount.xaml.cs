using Controller.UsersControlers;
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

namespace HealthClinic.View.WorkPeople
{
    /// <summary>
    /// Interaction logic for UpdateSecretaryAccount.xaml
    /// </summary>
    public partial class UpdateSecretaryAccount : Window
    {
        private readonly UserController userController;
        private Secretary secretaryAccount;

        public UpdateSecretaryAccount(ViewSecretary secretary)
        {
            InitializeComponent();
            InputName.Focus();
            InputName.SelectAll();

            var app = Application.Current as App;
            userController = app.UserController;

            InputName.Text = secretary.Name;
            InputSurname.Text = secretary.Surname;
            InputJmbg.Text = secretary.Jmbg;
            InputDateOfBirthday.Text = secretary.DateOfBirthday.ToString();
            InputCity.Text = secretary.City;
            InputAddress.Text = secretary.Address;
            InputCountry.Text = secretary.Country;
            InputEmailAddress.Text = secretary.EmailAddress;
            InputMobilePhone.Text = secretary.PhoneNumber;
            InputUsername.Text = secretary.Username;
            InputPassword.Text = secretary.Password;
            secretaryAccount = (Secretary)userController.GetEntity(secretary.Id);
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

            secretaryAccount.Name = InputName.Text;
            secretaryAccount.Surname = InputSurname.Text;
            secretaryAccount.Jmbg = InputJmbg.Text;
            secretaryAccount.DateOfBirth = DateTime.Parse(InputDateOfBirthday.Text);
            secretaryAccount.City.Name = InputCity.Text;
            secretaryAccount.City.Adress = InputAddress.Text;
            secretaryAccount.City.Country.Name = InputCountry.Text;
            secretaryAccount.EMail = InputEmailAddress.Text;
            secretaryAccount.ContactNumber = InputMobilePhone.Text;
            secretaryAccount.UserName = InputUsername.Text;
            secretaryAccount.Password = InputPassword.Text;

            userController.UpdateEntity(secretaryAccount);
            // Dodaj da se izmeni i View

            this.Close();
            MessageBox.Show("Uspešno ste izmenili nalog sekretaru", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
