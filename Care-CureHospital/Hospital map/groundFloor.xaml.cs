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
    public partial class groundFloor : Window
    {
        public groundFloor()
        {
            InitializeComponent();
        }

        private void groundFloorClick(object sender, RoutedEventArgs e)
        {
            groundFloor p = new groundFloor();
            p.Show();
            this.Close();

        }

        private void firstFloor(object sender, RoutedEventArgs e)
        {
            firstFloor psprat = new firstFloor();
            psprat.Show();
            this.Close();
        }

        private void Map(object sender, RoutedEventArgs e)
        {
            MainWindow map = new MainWindow();
            map.Show();
            this.Close();
        }

        private void groundFloor2(object sender, RoutedEventArgs e)
        {
            groundFloor p = new groundFloor();
            p.Show();
            this.Close();

        }

        private void secondFloor(object sender, RoutedEventArgs e)
        {
            firstFloor psprat = new firstFloor();
            psprat.Show();
            this.Close();
        }
        private void Doctor3(object sender, MouseButtonEventArgs e)
        {
            infoDoctor3 info = new infoDoctor3();
            info.Show();
        }
        private void Doctor4(object sender, MouseButtonEventArgs e)
        {
            infoDoctor4 info = new infoDoctor4();
            info.Show();
        }
        private void Pharmacy(object sender, MouseButtonEventArgs e)
        {
            infoPharmacy info = new infoPharmacy();
            info.Show();
        }

        private void Surgery1(object sender, MouseButtonEventArgs e)
        {
           surgeryRoom1 info = new surgeryRoom1();
            info.Show();
        }

        private void Surgery2(object sender, MouseButtonEventArgs e)
        {
            surgeryRoom2 info = new surgeryRoom2();
            info.Show();
        }

        private void Surgery3(object sender, MouseButtonEventArgs e)
        {
            surgeryRoom3 info = new surgeryRoom3();
            info.Show();
        }

        private void Patology(object sender, MouseButtonEventArgs e)
        {
            patology info = new patology();
            info.Show();
        }

        private void Cardiology(object sender, MouseButtonEventArgs e)
        {
            cardiology info = new cardiology();
            info.Show();
        }

        private void Radiology(object sender, MouseButtonEventArgs e)
        {
            radiology info = new radiology();
            info.Show();
        }
    }

}
