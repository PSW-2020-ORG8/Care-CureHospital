﻿using System;
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

namespace HospitalMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Rectangle Dinamicly = new Rectangle();
        public ObservableCollection<Rectangles> Rectangle { get; set; }

        public ObservableCollection<RoomInformationWiev>  RoomsInfo{ get; set; }
        public object LayoutRoot { get; private set; }
        public string Id { get; private set; }

        public String Key="";

        public MainWindow()
        {
            InitializeComponent();
            CreateDynamicCanvas();
            DinamiclyDrawingRepository.GetInstance();
            
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
            
        }

        private void CreateDynamicCanvas()
        {
            Rectangle = new ObservableCollection<Rectangles>();
            Rectangle = DinamiclyDrawingRepository.GetInstance().GetAllRectangles();
            RoomsInfo= InformationEditRepository.GetInstance().GetAll();

            foreach (Rectangles r in Rectangle)
            {
                Rectangle rect = new Rectangle()
                {   
                    Fill = r.Paint,
                    Height = r.Height,
                    Width = r.Width
                   
                };

                TextBlock txtb = new TextBlock()
                {
                    Width = r.WidthText,
                    Height = r.HeightText,
                    Text = r.Text,
                    Background = r.Background
                };
                canvas.Children.Add(txtb);
                foreach (RoomInformationWiev room in RoomsInfo)
                {
                    if (r.Id.Equals(room.NameOfRoom))
                    {
                        Key = r.Id;
                        rect.MouseDown += RoomInformation;
                    }
                }

                Canvas.SetLeft(txtb, r.LeftText);
                Canvas.SetTop(txtb, r.TopText);
                Canvas.SetLeft(rect, r.Left);
                Canvas.SetTop(rect, r.Top);
                canvas.Children.Add(rect);
                
            }

        }

        private void RoomInformation(object sender, MouseButtonEventArgs e)
        {
            RoomInformation worktime1 = new RoomInformation(Key);
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

            if (search.Text.ToString().Equals("Room2")){
            InfoDoctor1 inf = new InfoDoctor1();
            inf.Show();
            }
            else
            {

                InfoDoctor2 inf2 = new InfoDoctor2();
                inf2.Show();

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
