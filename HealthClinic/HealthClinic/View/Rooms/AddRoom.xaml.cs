using Controller.RoomsControlers;
using HealthClinic.View.Converter;
using Model.Manager;
using Model.Term;
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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        private readonly RoomController roomController;

        public AddRoom()
        {
            InitializeComponent();
            this.DataContext = this;
            InputNubmerOfRoom.Focus();
            InputNubmerOfRoom.SelectAll();

            var app = Application.Current as App;
            roomController = app.RoomController;
        }

        private void Button_Click_Potvrdi(object sender, RoutedEventArgs e)
        {
            if (InputNubmerOfRoom.Text.Equals(""))
            {
                MessageBox.Show("Morate uneti broj sale", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (roomController.RoomWithRoomIDExist(InputNubmerOfRoom.Text))
            {
                MessageBox.Show("Broj sale koji ste uneli već postoji", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            Rooms.RoomView.Add(RoomConverter.ConvertRoomToRoomView(
                roomController.AddEntity(new Room(InputNubmerOfRoom.Text, new TypeOfRoom(ComboBoxTypeOfRoom.SelectedItem.ToString().Substring(38)),
                new List<InventaryRoom>()))));
            this.Close();
            MessageBox.Show("Uspešno ste dodali novu sobu", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
