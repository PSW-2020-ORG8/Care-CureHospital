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
    public partial class firstFloor : Window
    {
        public firstFloor()
        {
            InitializeComponent();
        }

        private void groundFloorClick(object sender, RoutedEventArgs e)
        {
            groundFloor p = new groundFloor();
            p.Show();
            this.Close();

        }

        private void firstFloor1(object sender, RoutedEventArgs e)
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
            groundFloor2 p = new groundFloor2();
            p.Show();
            this.Close();

        }

        private void secondFloor(object sender, RoutedEventArgs e)
        {
            firstFloor firstf = new firstFloor();
            firstf.Show();
            this.Close();
        }

        private void Room1(object sender, MouseButtonEventArgs e)
        {
            infoRoom info = new infoRoom();
            info.Show();
        }
        private void Doctor1(object sender, MouseButtonEventArgs e)
        {
            infoDoctor1 info = new infoDoctor1();
            info.Show();
        }
        private void Doctor2(object sender, MouseButtonEventArgs e)
        {
            infoDoctor1 info = new infoDoctor1();
            info.Show();
        }

    }

}
