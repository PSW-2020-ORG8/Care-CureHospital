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
    /// Interaction logic for WorkPeople.xaml
    /// </summary>
    public partial class WorkPeople : Window
    {
        public WorkPeople()
        {
            InitializeComponent();
        }

        private void Button_Click_NaloziLekara(object sender, RoutedEventArgs e)
        {
            var doctorAccounts = new DoctorAccounts();
            doctorAccounts.ShowDialog();
            this.Close();
        }

        private void Button_Click_NaloziSekretara(object sender, RoutedEventArgs e)
        {
            var secretaryAccounts = new SecretaryAccounts();
            secretaryAccounts.ShowDialog();
            this.Close();
        }

        private void Button_Click_PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
