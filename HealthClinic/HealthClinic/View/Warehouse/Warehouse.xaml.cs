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
    /// Interaction logic for Warehouse.xaml
    /// </summary>
    public partial class Warehouse : Window
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        private void Button_Click_Lekovi(object sender, RoutedEventArgs e)
        {
            var medicaments = new Medicaments();
            medicaments.ShowDialog();
            this.Close();
        }

        private void Button_Click_Oprema(object sender, RoutedEventArgs e)
        {
            var equipment = new Equipment();
            equipment.ShowDialog();
            this.Close();
        }

        private void Button_Click_PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
