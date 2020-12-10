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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HospitalMap.Code.Model.Canvas;
using HospitalMap.Code.Repository.RectangleRepository;
using HospitalMap.Code.Repository;
using HospitalMap.WPF;
using HospitalMap.Repository;
using HospitalMap.WPF.ModelWPF;
using HospitalMap.WPF.ModelWPF;
using HospitalMap.Code.Model;
using HospitalMap.Code.Repository.RoomInformatioRepository;
using HospitalMap.Code.Controller;
using HospitalMap.Code.Repository.DoctorsRepository;

namespace HospitalMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Rectangle Dinamicly = new Rectangle();
        public ObservableCollection<Rectangles> Rectangle { get; set; }

        public ObservableCollection<RoomInformationVieW>  RoomsInfo{ get; set; }

        public ObservableCollection<StorageModel> storage { get; set; }

        public ObservableCollection<WorkTimeViewModel> workTime { get; set; }

        public ObservableCollection<RoomInformationVieW> SearchedPatientsRooms { get; set; }
        public ObservableCollection<DoctorRoomView> SearchedDoctorsRooms { get; set; }

        public ObservableCollection<WorkTimeViewModel> SearchedAnotherRooms { get; set; }

        public object LayoutRoot { get; private set; }
        public string Id { get; private set; }

        

        public MainWindow()
        {
            InitializeComponent();
            CreateDynamicCanvas();
            DinamiclyDrawingRepository.GetInstance();
            StorageRepository.GetInstance();
            RoomWorkTimeRepository.GetInstance();
            
            Login login = new Login();
            login.Show();
            this.Close();
            
            
        }
        
        public MainWindow(int broj)
        {
            InitializeComponent();
            CreateDynamicCanvas();
            DinamiclyDrawingRepository.GetInstance();
            InformationEditRepository.GetInstance();
            StorageRepository.GetInstance();
            RoomWorkTimeRepository.GetInstance();
            DoctorsRoomRepository.GetInstance();

            SearchedPatientsRooms = new ObservableCollection<RoomInformationVieW>();
            SearchedDoctorsRooms = new ObservableCollection<DoctorRoomView>();
            SearchedAnotherRooms = new ObservableCollection<WorkTimeViewModel>();

            if (Login.role == 2)
            {


                EquipmnetRadioButon.Visibility = Visibility.Hidden;



            }

        }

        private void CreateDynamicCanvas()
        {
            Rectangle = new ObservableCollection<Rectangles>();
            Rectangle = DinamiclyDrawingRepository.GetInstance().GetAllRectangles();
            RoomsInfo= InformationEditRepository.GetInstance().GetAll();
            storage = StorageRepository.GetInstance().GetAllStorage();
            workTime = RoomWorkTimeRepository.GetInstance().GetAll();

            foreach (Rectangles r in Rectangle)
            {
                Rectangle rect = new Rectangle()
                {   
                    Fill = r.Paint,
                    Height = r.Height,
                    Width = r.Width,
                    Name=r.Id
                };

                TextBlock txtb = new TextBlock()
                {
                    Width = r.WidthText,
                    Height = r.HeightText,
                    Text = r.Text,
                    Background = r.Background
                };
                canvas.Children.Add(txtb);
                foreach (RoomInformationVieW room in RoomsInfo)
                {
                    if (r.Id.Equals(room.NameOfRoom))
                    {
                        rect.MouseDown += RoomInformation;
                    }
                }

                foreach ( StorageModel s in storage)
                {
                    if (r.Id.Equals(s.IdS))
                    {
                        rect.MouseDown += StorageInfo;
                    }
                }

                foreach (WorkTimeViewModel s in workTime)
                {
                    if (r.Id.Equals(s.IdOfRoom))
                    {
                        rect.MouseDown += WorkTimeInfo;
                    }
                }

                Canvas.SetLeft(txtb, r.LeftText);
                Canvas.SetTop(txtb, r.TopText);
                Canvas.SetLeft(rect, r.Left);
                Canvas.SetTop(rect, r.Top);
                canvas.Children.Add(rect);
                
            }

        }

        private void WorkTimeInfo(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            WorkTimeView s = new WorkTimeView(rect.Name);
            s.Show();
        }

        private void StorageInfo(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            Storage s = new Storage(rect.Name);
            s.Show();
        }

        private void RoomInformation(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            RoomInformation worktime1 = new RoomInformation(rect.Name);
            worktime1.Show();
        }

        private void GroundFloorClick(object sender, RoutedEventArgs e)
        {
            GroundFloor p = new GroundFloor();
            p.Show();
            this.Close();

        }

        private void FirstFloor(object sender, RoutedEventArgs e)

        {
            FirstFloor firstf = new FirstFloor();
            firstf.Show();
            this.Close();
        }

        private void Map(object sender, RoutedEventArgs e)
        {
            MainWindow map = new MainWindow(3);
            map.Show();
            this.Close();
        }

        private void GroundFloor2(object sender, RoutedEventArgs e)
        {
            GroundFloor2 p = new GroundFloor2();
            p.Show();
            this.Close();
        }

        private void SecondFloor(object sender, RoutedEventArgs e)
        {
            FirstFloor psprat = new FirstFloor();
            psprat.Show();
            this.Close();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {

           

            if (EquipmnetRadioButon.IsChecked == true && !search.Text.ToString().Equals("")) {
                ObservableCollection<StorageModel> equipments = new ObservableCollection<StorageModel>();
                equipments = StorageRepository.GetInstance().SearchedItemsByName(search.Text);

                if (equipments.Count == 0)
                {
                    MessageBox.Show("There are no items like '" + search.Text + "' in storage!", "Storage");
                    return;
                }

                Storage storage = new Storage(equipments);
                storage.Show();
                       
            }

            if (RoomsRadioButon.IsChecked == true)
            {
                SearchController _searchController = new SearchController();

                SearchedPatientsRooms = _searchController.SearchPatientsRooms(search.Text.ToString());
                SearchedDoctorsRooms = _searchController.SearchDoctorsRooms(search.Text.ToString());
                SearchedAnotherRooms = _searchController.SearchAnotherRooms(search.Text.ToString());

                if (SearchedPatientsRooms.Count == 0 && SearchedDoctorsRooms.Count == 0 && SearchedAnotherRooms.Count == 0)
                {
                    MessageBox.Show("There are no search results! ", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                SearchedRooms searchedRoom = new SearchedRooms(SearchedPatientsRooms, SearchedDoctorsRooms, SearchedAnotherRooms);
                searchedRoom.Show();

            }


            if (TermsRadioButon.IsChecked == true)
            {
                AllDoctors allDoc = new AllDoctors();
                allDoc.Show();

            }


        }

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            HospitalMap.WPF.Login.role = 0;
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
