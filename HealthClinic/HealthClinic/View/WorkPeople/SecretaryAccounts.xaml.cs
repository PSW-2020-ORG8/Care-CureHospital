using Controller.UsersControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
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

namespace HealthClinic.View.WorkPeople
{
    /// <summary>
    /// Interaction logic for SecretaryAccounts.xaml
    /// </summary>
    public partial class SecretaryAccounts : Window
    {
        public static RoutedCommand helpSchortcut = new RoutedCommand();

        private readonly UserController userController;

        public static ObservableCollection<ViewSecretary> SecretaryView { get; set; }

        public SecretaryAccounts()
        {
            InitializeComponent();
            this.DataContext = this;
            helpSchortcut.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(helpSchortcut, ShortKey_Click));
            InputSearch.Focus();
            InputSearch.SelectAll();

            var app = Application.Current as App;
            userController = app.UserController;

            SecretaryView = new ObservableCollection<ViewSecretary>(SecretaryConverter.ConvertSecretaryListToSecretaryViewList(
                userController.GetAllSecretaries()));
        }

        private void Button_Click_KreirajNoviNalog(object sender, RoutedEventArgs e)
        {
            var createSecretaryAccount = new CreateSecretaryAccount();
            createSecretaryAccount.ShowDialog();
        }

        private void Button_Click_Prikazi(object sender, RoutedEventArgs e)
        {
            var secretaryAccount = new SecretaryAccount((ViewSecretary)DataGridSecretary.SelectedItem);
            secretaryAccount.ShowDialog();
        }

        private void Button_Click_Izmeni(object sender, RoutedEventArgs e)
        {
            var updateSecretaryAccount = new UpdateSecretaryAccount((ViewSecretary)DataGridSecretary.SelectedItem);
            updateSecretaryAccount.ShowDialog();
        }

        private void Button_Click_Obrisi(object sender, RoutedEventArgs e)
        {
            ViewSecretary selectedSecretary = (ViewSecretary)DataGridSecretary.SelectedItem;
            User secretary = userController.GetEntity(selectedSecretary.Id);
            if (MessageBox.Show("Da li ste sigurni da želite da obrišete nalog sekretara?", "Pitanje", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                userController.DeleteEntity(secretary);
                SecretaryView.Remove(selectedSecretary);
                MessageBox.Show("Uspešno ste obrisali nalog sekretaru", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
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
