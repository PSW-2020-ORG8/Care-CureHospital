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
    public partial class groundFloor2 : Window
    {
        public groundFloor2()
        {
            InitializeComponent();
        }

        private void groundFloorClick(object sender, RoutedEventArgs e)
        {
            groundFloor p = new groundFloor();
            p.Show();
            this.Close();

        }

        private void FirstFloor(object sender, RoutedEventArgs e)
        {
            firstFloor firstf = new firstFloor();
            firstf.Show();
            this.Close();
        }

        private void Map(object sender, RoutedEventArgs e)
        {
            MainWindow map = new MainWindow();
            map.Show();
            this.Close();
        }

        private void groundFloor(object sender, RoutedEventArgs e)
        {
            groundFloor2 p = new groundFloor2();
            p.Show();
            this.Close();

        }

        private void secondFloor(object sender, RoutedEventArgs e)
        {
            firstFloor secondf = new firstFloor();
            secondf.Show();
            this.Close();
        }
        private void Doctor3(object sender, MouseButtonEventArgs e)
        {
            infoDoctor1 info = new infoDoctor1();
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

        private void SurgeryRoom2(object sender, MouseButtonEventArgs e)
        {
            surgeryRoom2 info = new surgeryRoom2();
            info.Show();
        }

        private void SurgeryRoom1(object sender, MouseButtonEventArgs e)
        {
            surgeryRoom1 info = new surgeryRoom1();
            info.Show();
        }

        private void SurgeryRoom3(object sender, MouseButtonEventArgs e)
        {
            surgeryRoom3 info = new surgeryRoom3();
            info.Show();
        }

        private void Radiology(object sender, MouseButtonEventArgs e)
        {
            radiology radiology = new radiology();
            radiology.Show();
        }

        private void Psychiatric(object sender, MouseButtonEventArgs e)
        {
            Psychiatric info = new Psychiatric();
            info.Show();
        }

        private void Neurology(object sender, MouseButtonEventArgs e)
        {
            Neurology info = new Neurology();
            info.Show();
        }
    }

}
