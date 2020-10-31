using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private Boolean buttonLogOut;
        public static RoutedCommand helpSchortcut = new RoutedCommand();

        public Home()
        {
            InitializeComponent();
            Date.Text = DateTime.Now.ToShortDateString(); ;
            Time.Text = DateTime.Now.ToString("HH:mm");
            helpSchortcut.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(helpSchortcut, ShortKey_Click));
            buttonLogOut = false;

            NameAndSurrname.Text = MainWindow.viewManager.Name + " " + MainWindow.viewManager.Surname;
        }

        private void ShortKey_Click(object sender, ExecutedRoutedEventArgs e)
        {
            var help = new Help();
            help.ShowDialog();
        }

        private void Button_Click_Magacin(object sender, RoutedEventArgs e)
        {
            var warehouse = new Warehouse();
            warehouse.ShowDialog();
        }

        private void Buttom_Click_Sale(object sender, RoutedEventArgs e)
        {
            var rooms = new Rooms();
            rooms.ShowDialog();
        }

        private void Button_Click_Zaposleni(object sender, RoutedEventArgs e)
        {
            var workPeople = new WorkPeople.WorkPeople();
            workPeople.ShowDialog();
        }

        private void Button_Click_PremestanjeOpreme(object sender, RoutedEventArgs e)
        {
            var relocationEquipment = new RelocationEquipment();
            relocationEquipment.ShowDialog();
        }

        private void Button_Click_Renoviranje(object sender, RoutedEventArgs e)
        {
            var renovation = new Renovation();
            renovation.ShowDialog();
        }

        private void Button_Click_RadnoVreme(object sender, RoutedEventArgs e)
        {
            var workingTimeForDoctors = new WorkingTimeForDoctors();
            workingTimeForDoctors.ShowDialog();
        }

        private void Button_Click_MojNalog(object sender, RoutedEventArgs e)
        {
            var account = new Account.Account();
            account.ShowDialog();
        }

        private void Button_Click_Izvestaji(object sender, RoutedEventArgs e)
        {
            var reports = new Reports();
            reports.ShowDialog();
        }

        private void Button_Click_Obavestenja(object sender, RoutedEventArgs e)
        {
            var notifications = new Notifications();
            notifications.ShowDialog();
        }

        private void Button_Click_Tutorijal(object sender, RoutedEventArgs e)
        {
            var tutorial = new Tutorial();
            tutorial.ShowDialog();
        }

        private void Button_Click_OdjaviSe(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.buttonLogOut = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!buttonLogOut)
            {
                e.Cancel = true;
                MessageBox.Show(
                   "Morate se odjaviti da bi ugasili aplikaciju",
                   "Greška",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
        }
    }
}
