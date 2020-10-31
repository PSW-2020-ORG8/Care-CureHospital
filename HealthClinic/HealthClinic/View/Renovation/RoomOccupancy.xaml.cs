using Controller.RoomsControlers;
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
    /// Interaction logic for RoomOccupancy.xaml
    /// </summary>
    public partial class RoomOccupancy : Window
    {
        public static RoutedCommand closeSchortcut = new RoutedCommand();

        private readonly RoomController roomController;

        public static ObservableCollection<ViewRoomOccupancy> RoomOccupancyView { get; set; }

        public RoomOccupancy()
        {
            InitializeComponent();
            this.DataContext = this;
            closeSchortcut.InputGestures.Add(new KeyGesture(Key.Escape));
            CommandBindings.Add(new CommandBinding(closeSchortcut, ShortKey_Click));

            var app = Application.Current as App;
            roomController = app.RoomController;

            List<ViewRoomOccupancy> roomOccupancy = new List<ViewRoomOccupancy>();
            DateTime firstDate = roomController.GetRoomByRoomID(Renovation.roomForRenovation.RoomID).FromDateTime;
            DateTime lastDate = roomController.GetRoomByRoomID(Renovation.roomForRenovation.RoomID).ToDateTime;
                    
            while (firstDate < lastDate)
            {
                roomOccupancy.Add(new ViewRoomOccupancy() { RoomID = Renovation.roomForRenovation.RoomID, Date = firstDate.ToString("dd.MM.yyyy.") });
                firstDate = firstDate.AddDays(1);
            }
                        
            RoomOccupancyView = new ObservableCollection<ViewRoomOccupancy>(roomOccupancy);
        }

        private void ShortKey_Click(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }     
    }
}
