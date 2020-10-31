using Controller.RoomsControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
using Model.Manager;
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
    /// Interaction logic for Renovation.xaml
    /// </summary>
    public partial class Renovation : Window
    {
        private readonly RenovationController renovationController;
        private readonly RoomController roomController;

        public static ObservableCollection<ViewRenovation> RenovationView { get; set; }
        public static ObservableCollection<Room> RoomsView { get; set; }

        public static Room roomForRenovation;

        public Renovation()
        {
            InitializeComponent();
            this.DataContext = this;
            DataPickerFromDataTime.SelectedDate = DateTime.Now.Date;
            DataPickerToDataTime.SelectedDate = DateTime.Now.Date;

            var app = Application.Current as App;
            renovationController = app.RenovationController;
            roomController = app.RoomController;

            roomForRenovation = roomController.GetFirstRoom(roomController.GetAllEntities().ToList());

            RoomsView = new ObservableCollection<Room>(roomController.GetAllEntities().ToList());
            RenovationView = new ObservableCollection<ViewRenovation>(RenovationConverter.ConvertRenovationListToRenovationViewList(
                renovationController.GetAllEntities().ToList()));
        }

        /*private Room[] separateOnTwoParts(Room roomForRenovation) // Napravi u servisu
        {
            Room[] rooms = new Room[2];
            rooms[0] = roomForRenovation;
            rooms[1] = new Room(roomForRenovation.RoomID.Replace("a", "b"),
                new TypeOfRoom(roomForRenovation.TypeOfRoom.ToString()), new List<InventaryRoom>());
            return rooms;
        }

        private void ConnectTwoParts(Room firstPartOfRoom, Room secondPartOfRoom) // Napravi u servisu za renoviranje
        {
            List<InventaryRoom> equipmentForRelocate = secondPartOfRoom.Equipment;
            foreach (InventaryRoom equipment in equipmentForRelocate)
                roomController.AddEquipmentInRoom(equipment, firstPartOfRoom.RoomID);
            roomController.DeleteEntity(secondPartOfRoom);
        }*/

        private bool ExistRenovation(Room roomForRenovation)    // Staviti u controleru public
        {
            foreach (Model.Term.Renovation oneRenovation in renovationController.GetAllEntities())
                if (oneRenovation.Room.GetId() == roomForRenovation.GetId())
                    return true;
            return false;
        }

        private bool ExistTwoParts(Room roomForRenovation)
        {
            foreach (Room room in roomController.GetAllEntities())
                if (room.RoomID.Equals(roomForRenovation.RoomID.Replace("a", "b")))
                    return true;
            return false;
        }

        private void Button_Click_ZakaziRenoviranje(object sender, RoutedEventArgs e)
        {
            roomForRenovation = (Room)ComboBoxRooms.SelectedItem;
            if (roomForRenovation.ToDateTime > (DateTime)DataPickerFromDataTime.SelectedDate)
            {
                MessageBox.Show("Sala je zauzeta za period koji ste uneli", "Neuspešno renoviranje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ExistRenovation(roomForRenovation)) // Pozovi iz kontrolera i stavi u kontroler public
            {
                MessageBox.Show("Već je zakazano renoviranje za izabranu salu", "Neuspešno renoviranje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (InputTextDescription.Text.Equals("")) 
            {
                MessageBox.Show("Morate uneti kratak opis za renoviranje", "Neuspešno renoviranje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ComboBoxSeparateOnTwoParts.SelectedItem.ToString().Substring(38).Equals("Da") && ComboBoxConnectTwoParts.SelectedItem.ToString().Substring(38).Equals("Ne"))
            {
                if (ExistTwoParts(roomForRenovation))
                {
                    MessageBox.Show("Sala je već podeljena na dva dela", "Neuspešno renoviranje", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                } // Podeli salu na dva dela
                roomForRenovation.TypeOfRoom.NameOfType = ComboBoxTypeOfRoom.SelectedItem.ToString().Substring(38); // Izmena tipa sale
                roomForRenovation.FromDateTime = (DateTime)DataPickerFromDataTime.SelectedDate; // Izmena perioda zauzetosti sale
                roomForRenovation.ToDateTime = (DateTime)DataPickerToDataTime.SelectedDate;
                Room[] twoPartsOfRoom = renovationController.SeparateOnTwoParts(roomForRenovation);
                RenovationView.Add(RenovationConverter.ConvertRenovationToRenovationView(
                    renovationController.AddEntity(new Model.Term.Renovation(InputTextDescription.Text, twoPartsOfRoom[0],
                    (DateTime)DataPickerFromDataTime.SelectedDate, (DateTime)DataPickerToDataTime.SelectedDate))));
                RenovationView.Add(RenovationConverter.ConvertRenovationToRenovationView(
                    renovationController.AddEntity(new Model.Term.Renovation(InputTextDescription.Text, twoPartsOfRoom[1],
                    (DateTime)DataPickerFromDataTime.SelectedDate, (DateTime)DataPickerToDataTime.SelectedDate))));
                roomController.AddEntity(twoPartsOfRoom[1]); // Dodaje se nova polovina sale
                roomController.UpdateEntity(twoPartsOfRoom[0]); // Zbog menjanja tipa sale i zauzetosti sale
                roomController.UpdateEntity(twoPartsOfRoom[1]);
                MessageBox.Show("Uspešno ste zakazali renoviranje sale", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (ComboBoxSeparateOnTwoParts.SelectedItem.ToString().Substring(38).Equals("Ne") && ComboBoxConnectTwoParts.SelectedItem.ToString().Substring(38).Equals("Da"))
            {
                if (!ExistTwoParts(roomForRenovation))
                {
                    MessageBox.Show("Sala ne može da se spoji jer nema dva dela", "Neuspešno renoviranje", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Spoji dva dela u jednu salu
                roomForRenovation.TypeOfRoom.NameOfType = ComboBoxTypeOfRoom.SelectedItem.ToString().Substring(38); // Izmena tipa sale
                roomForRenovation.FromDateTime = (DateTime)DataPickerFromDataTime.SelectedDate; // Izmena perioda zauzetosti sale
                roomForRenovation.ToDateTime = (DateTime)DataPickerToDataTime.SelectedDate;
                Room secondPartOfRoom = roomForRenovation;
                if(roomForRenovation.RoomID.Contains("a"))
                    secondPartOfRoom.RoomID = roomForRenovation.RoomID.Replace("a", "b");
                else if (roomForRenovation.RoomID.Contains("b"))
                    secondPartOfRoom.RoomID = roomForRenovation.RoomID.Replace("b", "a");
                renovationController.ConnectTwoParts(roomForRenovation, secondPartOfRoom);
                roomController.UpdateEntity(roomForRenovation); // Zbog menjanja tipa sale i zauzetosti sale
                MessageBox.Show("Uspešno ste zakazali renoviranje sale", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // Kada se ne radi ni deljenje ni spajanje sale na dva dela          
            roomForRenovation.TypeOfRoom.NameOfType = ComboBoxTypeOfRoom.SelectedItem.ToString().Substring(38); // Izmena tipa sale
            roomForRenovation.FromDateTime = (DateTime)DataPickerFromDataTime.SelectedDate; // Izmena perioda zauzetosti sale
            roomForRenovation.ToDateTime = (DateTime)DataPickerToDataTime.SelectedDate;
            Console.WriteLine(roomForRenovation.TypeOfRoom.NameOfType);
            RenovationView.Add(RenovationConverter.ConvertRenovationToRenovationView(
                 renovationController.AddEntity(new Model.Term.Renovation(InputTextDescription.Text, roomForRenovation,
                 (DateTime) DataPickerFromDataTime.SelectedDate, (DateTime) DataPickerToDataTime.SelectedDate))));
            roomController.UpdateEntity(roomForRenovation); // Zbog menjanja tipa sale i zauzetosti sale
            MessageBox.Show("Uspešno ste zakazali renoviranje sale", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_PrikaziZauzecaSale(object sender, RoutedEventArgs e)
        {
            var roomOccupancy = new RoomOccupancy();
            roomOccupancy.ShowDialog();
        }

        private void Button_Click_PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
