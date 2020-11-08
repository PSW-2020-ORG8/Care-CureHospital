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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital_map
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Prizemlje1_Click(object sender, RoutedEventArgs e)
        {
            prizemlje p = new prizemlje();
            p.Show();
            this.Close();

        }

        private void Sprat1(object sender, RoutedEventArgs e)
        {
            prviSprat psprat = new prviSprat();
            psprat.Show();
            this.Close();
        }

        private void Mapa(object sender, RoutedEventArgs e)
        {
            MainWindow mapa = new MainWindow();
            mapa.Show();
            this.Close();
        }

        private void Prizemlje2(object sender, RoutedEventArgs e)
        {
            prizemlje2 p = new prizemlje2();
            p.Show();
            this.Close();
        }

        private void Sprat2(object sender, RoutedEventArgs e)
        {
            prviSprat psprat = new prviSprat();
            psprat.Show();
            this.Close();
        }

        private void RadnoVreme(object sender, MouseButtonEventArgs e)
        {
            Radno_vreme_bolnice radnoVreme = new Radno_vreme_bolnice();
            radnoVreme.Show();
        }
    }
}
