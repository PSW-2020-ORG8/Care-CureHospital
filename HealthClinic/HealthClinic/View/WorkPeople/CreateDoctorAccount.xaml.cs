using Controller.UsersControlers;
using HealthClinic.View.Converter;
using Model.AllActors;
using Model.Doctor;
using Repository.UsersRepository;
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
    /// Interaction logic for CreateDoctorAccount.xaml
    /// </summary>
    public partial class CreateDoctorAccount : Window
    {
        private readonly UserController userController;

        public CreateDoctorAccount()
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
                InputEmailAddress.Text.Equals("") || InputVocation.Text.Equals("") || InputUsername.Text.Equals("") || InputPassword.Text.Equals(""))
            {
                MessageBox.Show("Morate popuniti sva polja", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(userController.GetUserByUsername(InputUsername.Text) == null)
            {
                DoctorAccounts.DoctorsView.Add(DoctorConverter.ConvertDoctorToDoctorView(
                (Doctor)userController.AddEntity(new Doctor(InputUsername.Text, InputPassword.Text, InputName.Text, InputSurname.Text, InputJmbg.Text,
                DateTime.Parse(InputDateOfBirthday.Text), InputMobilePhone.Text, InputEmailAddress.Text,
                new City(InputCity.Text, InputCity.Text, new Country(InputCountry.Text)), new Specialitation(InputVocation.Text)))));               
                SpecialitationRepository.Instance().AddEntity(new Specialitation(InputVocation.Text)); // Dodaje specijalizaciju u fajl
                this.Close();
                MessageBox.Show("Uspešno ste kreirali nalog lekaru", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
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
