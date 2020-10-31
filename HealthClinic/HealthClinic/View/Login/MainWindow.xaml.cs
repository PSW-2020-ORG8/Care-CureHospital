using Controller.UsersControlers;
using HealthClinic.View;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
using Model.AllActors;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthClinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<ViewManager> managersView { get; set; }
        public static Manager loggedInManager;
        public static ViewManager viewManager;

        private readonly UserController userController;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            userController = app.UserController;

            managersView = new ObservableCollection<ViewManager>(ManagerConverter.ConvertManagerListToManagerViewList(
                userController.GetAllManagers().ToList()));
        }

        private void Button_Click_UlogujSe(object sender, RoutedEventArgs e)
        {
            if (!IsUsernameExist(InputUsername.Text)) // Pozovi iz kontrolera
            {
                MessageBox.Show("Uneli ste pogrešno korisničko ime", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                loggedInManager = (Manager)userController.Login(InputUsername.Text, InputPassword.Password.ToString());
            }
            catch
            {
                MessageBox.Show("Uneli ste nevalidno korisničko ime i lozinku", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (loggedInManager != null)
            {
                viewManager = ManagerConverter.ConvertManagerToManagerView(MainWindow.loggedInManager);
                var home = new Home();
                home.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Uneli ste pogrešnu lozinku ime", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }

        public bool IsUsernameExist(String username)
        {
            foreach (User user in userController.GetAllEntities())
                if (user.UserName.Equals(username))
                    return true;
            return false;
        }

        private void Button_Click_ZaboravljenaLozinka(object sender, RoutedEventArgs e)
        {
            LoginGrid.Children.Clear();
            UserControl usc = new ForgottenPassword();
            LoginGrid.Children.Add(usc);
        }

        private void Button_Click_Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
