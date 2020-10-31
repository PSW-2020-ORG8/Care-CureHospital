using Controller.UsersControlers;
using HealthClinic.View.Converter;
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
    /// Interaction logic for UpdateDoctorAccount.xaml
    /// </summary>
    public partial class UpdateDoctorAccount : Window
    {
        private readonly UserController userController;
        private Doctor doctorAccount;

        public UpdateDoctorAccount(ViewDoctor doctor)
        {
            InitializeComponent();
            InputName.Focus();
            InputName.SelectAll();

            var app = Application.Current as App;
            userController = app.UserController;

            InputName.Text = doctor.Name;
            InputSurname.Text = doctor.Surname;
            InputJmbg.Text = doctor.Jmbg;
            InputDateOfBirthday.Text = doctor.DateOfBirthday.ToString();
            InputCity.Text = doctor.City;
            InputAddress.Text = doctor.Address;
            InputCountry.Text = doctor.Country;
            InputEmailAddress.Text = doctor.EmailAddress;
            InputMobilePhone.Text = doctor.PhoneNumber;
            InputVocation.Text = doctor.Spetialitation;
            InputUsername.Text = doctor.Username;
            InputPassword.Text = doctor.Password;
            doctorAccount = (Doctor)userController.GetEntity(doctor.Id);
        }

        private void Button_Click_Potvrdi(object sender, RoutedEventArgs e)
        {
            if (InputName.Text.Equals("") || InputSurname.Text.Equals("") || InputJmbg.Text.Equals("") || InputDateOfBirthday.Equals("") ||
                 InputAddress.Text.Equals("") || InputCity.Text.Equals("") || InputCountry.Text.Equals("") || InputMobilePhone.Text.Equals("") ||
                 InputEmailAddress.Text.Equals("") || InputVocation.Text.Equals("") || InputUsername.Text.Equals("") || InputPassword.Text.Equals(""))
            {
                MessageBox.Show("Morate popuniti sva polja", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            doctorAccount.Name = InputName.Text;
            doctorAccount.Surname = InputSurname.Text;
            doctorAccount.Jmbg = InputJmbg.Text;
            doctorAccount.DateOfBirth = DateTime.Parse(InputDateOfBirthday.Text);
            doctorAccount.City.Name = InputCity.Text;
            doctorAccount.City.Adress = InputAddress.Text;
            doctorAccount.City.Country.Name = InputCountry.Text;
            doctorAccount.EMail = InputEmailAddress.Text;
            doctorAccount.ContactNumber = InputMobilePhone.Text;
            doctorAccount.Specialitation.SpecialitationForDoctor = InputVocation.Text;
            doctorAccount.UserName = InputUsername.Text;
            doctorAccount.Password = InputPassword.Text;

            userController.UpdateEntity(doctorAccount); 
            // Dodaj da se izmeni i View

            this.Close();
            MessageBox.Show("Uspešno ste izmenili nalog lekaru", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
