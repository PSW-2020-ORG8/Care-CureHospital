using Controller.RoomsControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
using Model.Term;
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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        public static RoutedCommand helpSchortcut = new RoutedCommand();

        private readonly RoomController roomController;

        public static ObservableCollection<ViewRoom> RoomView { get; set; }

        public Rooms()
        {
            InitializeComponent();
            this.DataContext = this;
            helpSchortcut.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(helpSchortcut, ShortKey_Click));
            InputSearch.Focus();
            InputSearch.SelectAll();

            var app = Application.Current as App;
            roomController = app.RoomController;

            RoomView = new ObservableCollection<ViewRoom>(RoomConverter.ConvertRoomListToRoomtViewList(
                roomController.GetAllEntities().ToList()));
        }

        private void Button_Click_DodajNovuSalu(object sender, RoutedEventArgs e)
        {
            var addRoom = new AddRoom();
            addRoom.ShowDialog();
        }       

        private void Button_Click_Prikazi(object sender, RoutedEventArgs e)
        {
            var medicalEquipment = new MedicalEquipment();
            medicalEquipment.ShowDialog();
        }

        private void Button_Click_Obrisi(object sender, RoutedEventArgs e)
        {
            ViewRoom selectedRoom = (ViewRoom)DataGridRooms.SelectedItem;
            Room room = roomController.GetEntity(selectedRoom.Id);
            if (MessageBox.Show("Da li ste sigurni da želite da obrišete sobu?", "Pitanje", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                roomController.DeleteEntity(room);
                RoomView.Remove(selectedRoom);
                MessageBox.Show("Uspešno ste obrisali sobu", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
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
