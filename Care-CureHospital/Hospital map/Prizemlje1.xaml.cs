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
    /// Interaction logic for Prizemlje1.xaml
    /// </summary>
    public partial class Prizemlje1 : Window
    {
        public Prizemlje1()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kompleks_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mapa = new MainWindow();
            mapa.Show();
            this.Close();

        }

        private void Prizemlje1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sprat1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
