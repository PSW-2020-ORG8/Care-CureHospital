using HospitalMap.Controller;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for RoomInformation.xaml
    /// </summary>
    public partial class RoomInformation : Window
    {
        private InformationEditController informationControler = new InformationEditController();
        public RoomInformationVieW room
        {
            get;
            set;
        }

        public RoomInformation()
        {
            InitializeComponent();
            this.DataContext = this;

            if (Login.role != 3)
            {

                ButonSave.Visibility = Visibility.Hidden;

                Roomtxt.IsEnabled = false;
                FloorTxt.IsEnabled = false;
                BedCapacityTxt.IsEnabled = false;
                OcupiedBedsTxt.IsEnabled = false;
                AvailableBedsTxt.IsEnabled = false;
                ClinicTxt.IsEnabled = false;


            }

            room = informationControler.GetRoomById("2");


        }


        public RoomInformation(String id)
        {
            InitializeComponent();
            this.DataContext = this;


            if (Login.role != 3)
            {

                ButonSave.Visibility = Visibility.Hidden;

                Roomtxt.IsEnabled = false;
                FloorTxt.IsEnabled = false;
                BedCapacityTxt.IsEnabled = false;
                OcupiedBedsTxt.IsEnabled = false;
                AvailableBedsTxt.IsEnabled = false;
                ClinicTxt.IsEnabled = false;


            }
            if (Login.role == 2) {
                BedCapacityTxt.Visibility = Visibility.Hidden;
                OcupiedBedsTxt.Visibility = Visibility.Hidden;
                AvailableBedsTxt.Visibility = Visibility.Hidden;
                BedCapacity.Visibility = Visibility.Hidden;
                OccupiedBeds.Visibility = Visibility.Hidden;
                AvailableBeds.Visibility = Visibility.Hidden;

            }

            room = informationControler.GetRoomById(id);
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            informationControler.EditInformation(room);
            this.Close();


        }
    }
}
