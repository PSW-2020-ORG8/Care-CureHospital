using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalMap.WPF
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        public Schedule()
        {
            InitializeComponent();
            DatumS.SelectedDate = DateTime.Today;
            DatumE.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime Ds = new DateTime();
            Ds = (DateTime)DatumS.SelectedDate;
            DateTime De = new DateTime();
            De = (DateTime)DatumE.SelectedDate;
            Specialization s = new Specialization(Ds,De);
            s.Show();
            this.Close();
        }
    }
}
