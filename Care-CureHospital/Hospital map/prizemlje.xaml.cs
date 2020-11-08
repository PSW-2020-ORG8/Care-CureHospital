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

namespace Hospital_map
{
    /// <summary>
    /// Interaction logic for prizemlje.xaml
    /// </summary>
    public partial class prizemlje : Window
    {
        public prizemlje()
        {
            InitializeComponent();
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
        private void Lekar3(object sender, MouseButtonEventArgs e)
        {
            infoLekar3 info = new infoLekar3();
            info.Show();
        }
        private void Lekar4(object sender, MouseButtonEventArgs e)
        {
            infoLekar4 info = new infoLekar4();
            info.Show();
        }
        private void Apoteka1(object sender, MouseButtonEventArgs e)
        {
            infoApoteka info = new infoApoteka();
            info.Show();
        }

        private void OpSala1(object sender, MouseButtonEventArgs e)
        {
           operacionaSala1 info = new operacionaSala1();
            info.Show();
        }

        private void OpSala2(object sender, MouseButtonEventArgs e)
        {
            operacionasala2 info = new operacionasala2();
            info.Show();
        }

        private void Patologija(object sender, MouseButtonEventArgs e)
        {
            patologija info = new patologija();
            info.Show();
        }

        private void Kardiologija(object sender, MouseButtonEventArgs e)
        {
            kardiologija info = new kardiologija();
            info.Show();
        }

        private void Radiologija(object sender, MouseButtonEventArgs e)
        {
            radiologija info = new radiologija();
            info.Show();
        }
    }

}
