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
    /// Interaction logic for MedicalEquipment.xaml
    /// </summary>
    public partial class MedicalEquipment : Window
    {
        public static RoutedCommand closeSchortcut = new RoutedCommand();

        public MedicalEquipment()
        {
            InitializeComponent();
            closeSchortcut.InputGestures.Add(new KeyGesture(Key.Escape));
            CommandBindings.Add(new CommandBinding(closeSchortcut, ShortKey_Click));
        }

        private void ShortKey_Click(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
