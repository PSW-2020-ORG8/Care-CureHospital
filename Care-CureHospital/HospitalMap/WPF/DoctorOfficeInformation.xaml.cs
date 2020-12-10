using HospitalMap.Code.Model;
using HospitalMap.Code.Repository;
using HospitalMap.Code.Repository.DoctorsRepository;
using HospitalMap.Controller;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DoctorOfficeInformation.xaml
    /// </summary>
    public partial class DoctorOfficeInformation : Window
    {

       
        


        private InformationEditController _informationControler = new InformationEditController();
        public DoctorRoomView DoctorsRoom
        {
            get;
            set;
        }


        public  ObservableCollection<DoctorRoomView> AllDoctors
        {
            get;
            set;
        }

        public ObservableCollection<string> AllNameAndSurnameAndJmbgFromDoctors
        {
            get;
            set;
        }

        private static string _idRoom;
        public DoctorOfficeInformation(string Id)
        {
            
            InitializeComponent();
            this.DataContext = this;


            if(Login.role != 3)
            {

                NewDoctor.Visibility= Visibility.Hidden;
                ButtonSave.Visibility = Visibility.Hidden;
                DoctorsComboBox.Visibility = Visibility.Hidden;
                FromTXT.IsEnabled = false;
                ToTXT.IsEnabled = false;
                NameOfCurrentDoctor.IsEnabled = false;
                SurnameOfCurrentDoctor.IsEnabled = false;

                

                NumberOfFloorTxt.IsEnabled = false;
                NameOfClinicTxt.IsEnabled = false;



            }


             DoctorsRoom = _informationControler.GetDoctorsRoomById(Id);

            _idRoom = Id;



            AllNameAndSurnameAndJmbgFromDoctors = new ObservableCollection<string>();

            AllDoctors = DoctorsRoomRepository.GetInstance().GetAll();

            foreach (DoctorRoomView doctor in AllDoctors)
            {
                if (!doctor.JmbgOfDoctor.Equals(DoctorsRoom.JmbgOfDoctor))
                {
                    AllNameAndSurnameAndJmbgFromDoctors.Add(doctor.NameOfDoctor + " " + doctor.SurnameOfDoctor + " Jmbg:" + doctor.JmbgOfDoctor);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!DoctorsComboBox.Text.ToString().Equals(""))
            {


                string _selectedDoctor = DoctorsComboBox.Text;

                string[] niz = _selectedDoctor.Split(':');

                string _selectedDoctorJmbg = niz[1];

                int from= Int32.Parse(DoctorsRoom.FromDateTime);
                int to= Int32.Parse(DoctorsRoom.ToDateTime);

                if(from >= to)
                {
                    MessageBox.Show("The initial hourly rate must be less than the final hourly rate! ", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _informationControler.AddNewDoctorOnInformation(DoctorsRoom, _selectedDoctorJmbg);


                
                this.Close();

            }
            else
            {
                int from = Int32.Parse(DoctorsRoom.FromDateTime);
                int to = Int32.Parse(DoctorsRoom.ToDateTime);

                if (from >= to)
                {
                    MessageBox.Show("The initial hourly rate must be less than the final hourly rate! ", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _informationControler.EditCurrentDoctorOnInformation(DoctorsRoom);

                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ObservableCollection<StorageModel> equipments = new ObservableCollection<StorageModel>();
            equipments = StorageRepository.GetInstance().SearchedItemsByRoom(_idRoom);

            if (equipments.Count == 0)
            {
                MessageBox.Show("There are no items in room !", "Storage");
                return;
            }

            RoomItems room = new RoomItems(equipments);
            room.Show();
        }
    }
}
