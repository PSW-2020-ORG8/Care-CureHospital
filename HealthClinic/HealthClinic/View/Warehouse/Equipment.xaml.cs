using Controller;
using Controller.RoomsControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
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
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Window
    {
        public static RoutedCommand helpSchortcut = new RoutedCommand();

        private readonly EquipmentController equipmentController;

        public static ObservableCollection<ViewEquipment> EquipmentView { get; set; }

        public Equipment()
        {
            InitializeComponent();
            this.DataContext = this;
            helpSchortcut.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(helpSchortcut, ShortKey_Click));
            InputSearch.Focus();
            InputSearch.SelectAll();

            var app = Application.Current as App;
            equipmentController = app.EquipmentController;

            EquipmentView = new ObservableCollection<ViewEquipment>(EquipmentConverter.ConvertEquipmnetListToEquipmentViewList(
                equipmentController.GetAllEntities().ToList()));
        }

        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {
            var addEquipment = new AddEquipment();
            addEquipment.ShowDialog();
        }

        private void Button_Click_UnesiNovuOpremu(object sender, RoutedEventArgs e)
        {
            var addNewEquipment = new AddNewEquipment();
            addNewEquipment.ShowDialog();
        }

        private void Button_Click_Obrisi(object sender, RoutedEventArgs e)
        {
            ViewEquipment selectedEquipment = (ViewEquipment)DataGridEquipment.SelectedItem;
            Model.Manager.Equipment equipment = equipmentController.GetEntity(selectedEquipment.Id);
            if (MessageBox.Show("Da li ste sigurni da želite da obrišete lek?", "Pitanje", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                equipmentController.DeleteEntity(equipment);
                EquipmentView.Remove(selectedEquipment);
                MessageBox.Show("Uspešno ste obrisali lek", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var filtered = EquipmentView.Where(equipment => equipment.Code.StartsWith(InputSearch.Text)
            || equipment.Name.StartsWith(InputSearch.Text) || equipment.TypeOfEquipment.StartsWith(InputSearch.Text) 
            || equipment.Amount.ToString().StartsWith(InputSearch.Text));
            DataGridEquipment.ItemsSource = filtered;
        }
    }
}
