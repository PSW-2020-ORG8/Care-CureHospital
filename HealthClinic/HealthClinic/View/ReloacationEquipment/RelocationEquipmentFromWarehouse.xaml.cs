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
    /// Interaction logic for RelocationEquipmentFromWarehouse.xaml
    /// </summary>
    public partial class RelocationEquipmentFromWarehouse : Window
    {
        private readonly RoomController roomController;
        private readonly EquipmentController equipmentController;
        private readonly InventaryRoomController inventaryRoomController;

        public static ObservableCollection<ViewInventaryRoom> InRoomView { get; set; }
        public static ObservableCollection<ViewEquipment> WarehouseView { get; set; }
        public static ObservableCollection<Room> RoomsView { get; set; }
        private Room inRoom;

        public RelocationEquipmentFromWarehouse()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            roomController = app.RoomController;
            equipmentController = app.EquipmentController;
            inventaryRoomController = app.InventaryRoomController;

            inRoom = (Room)ComboBoxInRoom.SelectedItem;

            inRoom = roomController.GetFirstRoom(roomController.GetAllEntities().ToList());

            RoomsView = new ObservableCollection<Room>(roomController.GetAllEntities().ToList());
            InRoomView = new ObservableCollection<ViewInventaryRoom>(InventaryRoomConverter.ConvertInventaryRoomListToInventaryRoomViewList(inRoom.Equipment));
            WarehouseView = new ObservableCollection<ViewEquipment>(EquipmentConverter.ConvertEquipmnetListToEquipmentViewList(
                equipmentController.GetAllEntities().ToList()));
        }

        private void Button_Click_Premesti(object sender, RoutedEventArgs e)
        {          
            try
            {
                int.Parse(InputAmountOfEquipment.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Morate uneti broj za količinu", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (ViewEquipment equipmentForRelocate in WarehouseView)
            {
                if (equipmentForRelocate.Name.Equals(InputNameOfEquipment.Text))
                {
                    if (equipmentForRelocate.Amount < int.Parse(InputAmountOfEquipment.Text))
                    {
                        MessageBox.Show("Ne postoji dovoljna količina opreme koju želite da premestite", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    foreach (ViewInventaryRoom equipmentInRoom in InRoomView)
                    {
                        if (equipmentInRoom.Name.Equals(InputNameOfEquipment.Text))
                        {   // Premestanje opreme koja vec postoji u sali
                            equipmentForRelocate.Amount -= int.Parse(InputAmountOfEquipment.Text);
                            equipmentInRoom.Quantity += int.Parse(InputAmountOfEquipment.Text);
                            Model.Manager.Equipment equipmentForReloceate = equipmentController.GetEntity(equipmentForRelocate.Id);
                            InventaryRoom inventaryRoom = inventaryRoomController.GetEntity(equipmentInRoom.Id);
                            equipmentForReloceate.Amount -= int.Parse(InputAmountOfEquipment.Text);
                            inventaryRoom.Quantity += int.Parse(InputAmountOfEquipment.Text);
                            equipmentController.UpdateEntity(equipmentForReloceate);
                            inventaryRoomController.UpdateEntity(inventaryRoom);
                            MessageBox.Show("Uspešno ste premestili opremu", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                    } // Premestanje opreme koja ne postoji u prvoj sali
                    equipmentForRelocate.Amount -= int.Parse(InputAmountOfEquipment.Text);
                    Model.Manager.Equipment equipment = equipmentController.GetEntity(equipmentForRelocate.Id);
                    equipment.Amount -= int.Parse(InputAmountOfEquipment.Text);
                    equipmentController.UpdateEntity(equipment);
                    InRoomView.Add(InventaryRoomConverter.ConvertInventaryRoomToInventaryRoomView(
                        new InventaryRoom(GetLastIDForInventaryRoom(), equipmentForRelocate.Name, int.Parse(InputAmountOfEquipment.Text))));
                    // Dodaje opremu u inventoryRoom.csv i u sobu
                    Room roomWithNewEquipment = roomController.GetEntity(inRoom.GetId());                    
                    roomWithNewEquipment.Equipment.Add(
                        inventaryRoomController.AddEntity(new InventaryRoom(equipmentForRelocate.Name, int.Parse(InputAmountOfEquipment.Text))));
                    roomController.UpdateEntity(roomWithNewEquipment);                   
                    MessageBox.Show("Uspešno ste premestili opremu", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            MessageBox.Show("Ne postoji oprema koju želite da premestite", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        private int GetLastIDForInventaryRoom()
        {
            int lastID = 0;
            foreach (InventaryRoom inventary in inventaryRoomController.GetAllEntities())
                lastID++;
            return lastID;
        }

        private void Button_Click_PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EquipmentInRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InRoomView.Clear();
            inRoom = (Room)ComboBoxInRoom.SelectedItem;
            foreach (InventaryRoom equipment in inRoom.Equipment)
                InRoomView.Add(InventaryRoomConverter.ConvertInventaryRoomToInventaryRoomView(equipment));
        }
    }
}
