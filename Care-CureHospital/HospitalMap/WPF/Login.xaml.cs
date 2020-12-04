using HospitalMap.Code.Controller;
using HospitalMap.Code.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalMap.WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ObservableCollection<LoginModel> logins = new LoginController().GetAllLogins();
        public static int role=0;
        

        public Login()
        {
            
            InitializeComponent();

        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Password;
            errorCredentials.Visibility = Visibility.Hidden;

            if (logins.Count != 0)
            {
                foreach (LoginModel login in logins)
                {
                    if (login.Username.Equals(username) && login.Password.Equals(password))
                    {
                        if (login.Role.Equals("L"))
                        {
                            role = 1;
                        }
                        else if (login.Role.Equals("P"))
                        {
                            role = 2;
                        }
                        else if (login.Role.Equals("U"))
                        {
                            role = 3;
                        }
                        else {
                            role = 4;
                        }
                                
                        MainWindow mainWindow = new MainWindow(3);
                        mainWindow.Show();
                        this.Close();
                    }
                }
                errorCredentials.Visibility = Visibility.Visible;
            }

        }

        
    }
}
