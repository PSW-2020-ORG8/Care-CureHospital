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
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        private ViewManager viewManager;

        public Account()
        {
            InitializeComponent();

            viewManager = ManagerConverter.ConvertManagerToManagerView(MainWindow.loggedInManager);

            LabelName.Content = viewManager.Name;
            LabelSurname.Content = viewManager.Surname;
            LabelJmbg.Content = viewManager.Jmbg;
            LabelDateOfBirthday.Content = viewManager.DateOfBirthday;
            LabelCity.Content = viewManager.City;
            LabelAddress.Content = viewManager.Address;
            LabelCountry.Content = viewManager.Country;
            LabelEmailAddress.Content = viewManager.EmailAddress;
            LabelMobilePhone.Content = viewManager.PhoneNumber;
            LabelUsername.Content = viewManager.Username;
            LabelPassword.Content = viewManager.Password;
        }

        private void Button_Click_IzmeniNalog(object sender, RoutedEventArgs e)
        {
            var updateAccount = new UpdateAccount();
            updateAccount.ShowDialog();
            this.Close();
        }

        private void Button_Click_PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
