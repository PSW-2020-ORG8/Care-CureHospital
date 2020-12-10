using HospitalMap.Code.Model;
using HospitalMap.Code.Model.Canvas;
using HospitalMap.Code.Repository;
using HospitalMap.Code.Repository.DoctorsRepository;
using HospitalMap.Code.Repository.RectangleRepository;
using HospitalMap.Repository;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace HospitalMap.WPF
{
    /// <summary>
    /// Interaction logic for prviSprat.xaml
    /// </summary>
    public partial class FirstFloor : Window, INotifyPropertyChanged
    {
        public Rectangle Dinamicly = new Rectangle();
        public ObservableCollection<Rectangles> Rectangle { get; set; }

        public ObservableCollection<RoomInformationVieW> RoomsInfo { get; set; }

        public ObservableCollection<DoctorRoomView> DrOfficeInfo { get; set; }

        public ObservableCollection<StorageModel> storage { get; set; }

        public Rectangles SearchedRectangle = new Rectangles();


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private RoomInformationVieW _room;

        public RoomInformationVieW Room
        {
            get
            {
                return _room;
            }
            set
            {
                if (value != _room)
                {
                    _room = value;
                    OnPropertyChanged("Room");
                }
            }
        }
        public FirstFloor()
        {
            InitializeComponent();
            CreateDynamicCanvas();
            FirstFloorRepository.GetInstance();
            InformationEditRepository.GetInstance();
            DoctorsRoomRepository.GetInstance();
            StorageRepository.GetInstance();
            Room = InformationEditRepository.GetInstance().GetById("R1");
            RoomTxt.Text = Room.NameOfRoom;
        }

        public FirstFloor(string Id)
        {
            InitializeComponent();
            CreateDynamicCanvas();
            FirstFloorRepository.GetInstance();
            InformationEditRepository.GetInstance();
            DrawSelectedRectangle(Id);
            DoctorsRoomRepository.GetInstance();
            StorageRepository.GetInstance();
            Room = InformationEditRepository.GetInstance().GetById("R1");
            RoomTxt.Text = Room.NameOfRoom;
        }

        private void DrawSelectedRectangle(string Id)
        {
            SearchedRectangle = FirstFloorRepository.GetInstance().GetById(Id);

            Rectangle rect = new Rectangle()
            {

                Fill = Brushes.Transparent,
                Height = SearchedRectangle.Height,
                Width = SearchedRectangle.Width,
                Name = SearchedRectangle.Id,
                Stroke = Brushes.Red,
                StrokeThickness = 5

            };
            Canvas.SetLeft(rect, SearchedRectangle.Left);
            Canvas.SetTop(rect, SearchedRectangle.Top);
            canvas.Children.Add(rect);
        }

        private void CreateDynamicCanvas()
        {
            Rectangle = new ObservableCollection<Rectangles>();
            Rectangle = FirstFloorRepository.GetInstance().GetAllRectangles();
            RoomsInfo = InformationEditRepository.GetInstance().GetAll();
            DrOfficeInfo = DoctorsRoomRepository.GetInstance().GetAll();
            storage = StorageRepository.GetInstance().GetAllStorage();

            foreach (Rectangles r in Rectangle)
            {
                Rectangle rect = new Rectangle()
                {
                    Fill = r.Paint,
                    Height = r.Height,
                    Width = r.Width,
                    Name = r.Id
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
                    if (r.Id.Equals(room.IdOfRoom))
                    {
                        rect.MouseDown += RoomInformation;
                    }
                }

                foreach (DoctorRoomView room in DrOfficeInfo)
                {
                    if (r.Id.Equals(room.IdOfRoom))
                    {
                        rect.MouseDown += DrOfficeInformation;
                    }
                }

                foreach (StorageModel s in storage)
                {
                    if (r.Id.Equals(s.IdS))
                    {
                        rect.MouseDown += StorageInfo;
                        break;
                    }
                }

                Canvas.SetLeft(txtb, r.LeftText);
                Canvas.SetTop(txtb, r.TopText);
                Canvas.SetLeft(rect, r.Left);
                Canvas.SetTop(rect, r.Top);
                canvas.Children.Add(rect);
                
            }

        }

        private void StorageInfo(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            RoomItems s = new RoomItems("", rect.Name);
            s.Show();
        }

        private void RoomInformation(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            RoomInformation worktime1 = new RoomInformation(rect.Name);
            worktime1.Show(); 
        }

     


        private void DrOfficeInformation(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            DoctorOfficeInformation worktime1 = new DoctorOfficeInformation(rect.Name);
            worktime1.Show();
        }

        private void GroundFloorClick(object sender, RoutedEventArgs e)
        {
            GroundFloor p = new GroundFloor();
            p.Show();
            this.Close();

        }

        private void FirstFloor1(object sender, RoutedEventArgs e)
        {
            FirstFloor psprat = new FirstFloor();
            psprat.Show();
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
            FirstFloor firstf = new FirstFloor();
            firstf.Show();
            this.Close();
        }

        private void Room1(object sender, MouseButtonEventArgs e)
        {
            RoomInformation room = new RoomInformation();
            room.Show();
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
