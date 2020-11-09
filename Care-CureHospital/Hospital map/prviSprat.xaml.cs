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
    /// Interaction logic for prviSprat.xaml
    /// </summary>
    public partial class prviSprat : Window
    {
        public prviSprat()
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

        private void Soba1(object sender, MouseButtonEventArgs e)
        {
            InfoZaSobe info = new InfoZaSobe();
            info.Show();
        }
        private void Lekar1(object sender, MouseButtonEventArgs e)
        {
            infoLekar1 info = new infoLekar1();
            info.Show();
        }
        private void Lekar2(object sender, MouseButtonEventArgs e)
        {
            infoLekar2xaml info = new infoLekar2xaml();
            info.Show();
        }

    }

}
