using Controller.UsersControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
using HealthClinic.View.WorkPeople;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DoctorAccounts.xaml
    /// </summary>
    public partial class DoctorAccounts : Window
    {
        public static RoutedCommand helpSchortcut = new RoutedCommand();

        private readonly UserController userController;

        public static ObservableCollection<ViewDoctor> DoctorsView { get; set; }

        public DoctorAccounts()
        {
            InitializeComponent();
            this.DataContext = this;
            helpSchortcut.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(helpSchortcut, ShortKey_Click));
            InputSearch.Focus();
            InputSearch.SelectAll();

            var app = Application.Current as App;
            userController = app.UserController;

            DoctorsView = new ObservableCollection<ViewDoctor>(DoctorConverter.ConvertDoctorListToDoctorViewList(
                userController.GetAllDoctors()));
        }

        private void Button_Click_KreirajNoviNalog(object sender, RoutedEventArgs e)
        {
            var createDoctorAccount = new CreateDoctorAccount();
            createDoctorAccount.ShowDialog();
        }

        private void Button_Click_Prikazi(object sender, RoutedEventArgs e)
        {
            var doctorAccount = new DoctorAccount((ViewDoctor)DataGridDoctors.SelectedItem);
            doctorAccount.ShowDialog();
        }

        private void Button_Click_Izmeni(object sender, RoutedEventArgs e)
        {
            var updateDoctorAccount = new UpdateDoctorAccount((ViewDoctor)DataGridDoctors.SelectedItem);
            updateDoctorAccount.ShowDialog();
        }

        private void Button_Click_Obrisi(object sender, RoutedEventArgs e)
        {
            ViewDoctor selectedDoctor = (ViewDoctor)DataGridDoctors.SelectedItem;
            User doctor = userController.GetEntity(selectedDoctor.Id);
            if (MessageBox.Show("Da li ste sigurni da želite da obrišete nalog lekara?", "Pitanje", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                userController.DeleteEntity(doctor);
                DoctorsView.Remove(selectedDoctor);
                MessageBox.Show("Uspešno ste obrisali nalog lekaru", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShortKey_Click(object sender, ExecutedRoutedEventArgs e)
        {
            var helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
