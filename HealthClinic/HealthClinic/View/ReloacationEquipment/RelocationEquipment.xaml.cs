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
    /// Interaction logic for RelocationEquipment.xaml
    /// </summary>
    public partial class RelocationEquipment : Window
    {
        public RelocationEquipment()
        {
            InitializeComponent();
        }

        private void Button_Click_IzSale(object sender, RoutedEventArgs e)
        {
            var relocationEquipmentFromRoom = new RelocationEquipmentFromRoom();
            relocationEquipmentFromRoom.ShowDialog();
            this.Close();
        }

        private void Button_Click_IzMagacina(object sender, RoutedEventArgs e)
        {
            var relocationEquipmentFromWarehouse = new RelocationEquipmentFromWarehouse();
            relocationEquipmentFromWarehouse.ShowDialog();
            this.Close();
        }

        private void Button_Clock_PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
