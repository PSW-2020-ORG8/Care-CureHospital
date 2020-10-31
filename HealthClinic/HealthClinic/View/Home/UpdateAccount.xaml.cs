using Controller.UsersControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
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

namespace HealthClinic.View.Account
{
    /// <summary>
    /// Interaction logic for UpdateAccount.xaml
    /// </summary>
    public partial class UpdateAccount : Window
    {
        private readonly UserController userController;
        private ViewManager viewManager;

        public UpdateAccount()
        {
            InitializeComponent();
            InputName.Focus();
            InputName.SelectAll();
            var app = Application.Current as App;
            userController = app.UserController;

            viewManager = ManagerConverter.ConvertManagerToManagerView(MainWindow.loggedInManager);

            InputName.Text = viewManager.Name;
            InputSurname.Text = viewManager.Surname;
            InputJmbg.Text = viewManager.Jmbg;
            InputDateOfBirthday.Text = viewManager.DateOfBirthday.ToString();
            InputCity.Text = viewManager.City;
            InputAddress.Text = viewManager.Address;
            InputCountry.Text = viewManager.Country;
            InputEmailAddress.Text = viewManager.EmailAddress;
            InputMobilePhone.Text = viewManager.PhoneNumber;
            InputUsername.Text = viewManager.Username;
            InputPassword.Text = viewManager.Password;
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

            MainWindow.loggedInManager.Name = InputName.Text;
            MainWindow.loggedInManager.Surname = InputSurname.Text;
            MainWindow.loggedInManager.DateOfBirth = DateTime.Parse(InputDateOfBirthday.Text);
            MainWindow.loggedInManager.City.Name = InputCity.Text;
            MainWindow.loggedInManager.City.Adress = InputAddress.Text;
            MainWindow.loggedInManager.City.Country.Name = InputCountry.Text;
            MainWindow.loggedInManager.EMail = InputEmailAddress.Text;
            MainWindow.loggedInManager.ContactNumber = InputMobilePhone.Text;
            MainWindow.loggedInManager.UserName = InputUsername.Text;
            MainWindow.loggedInManager.Password = InputPassword.Text;
            userController.UpdateEntity(MainWindow.loggedInManager);
            MainWindow.viewManager.Name = InputName.Text;
            MainWindow.viewManager.Surname = InputSurname.Text;
            var account = new Account();
            account.ShowDialog();
            this.Close();
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            var account = new Account();
            account.ShowDialog();
            this.Close();
        }
    }
}
