using HospitalMap.Code.Controller;
using HospitalMap.WPF.Converter;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Priority.xaml
    /// </summary>
    public partial class Priority : Window
    {
        public static DateTime Dstart
        {
            get;
            set;
        }

        public static DateTime Dend
        {
            get;
            set;
        }

        public static DoctorView SelektovaniDoktor
        {
            get;
            set;
        }

        public static SpecializationView Selektovan
        {
            get;
            set;
        }
        public ObservableCollection<WorkDayViewView> SearchedRooms { get; set; }
        public Priority(DateTime DatumS, DateTime DatumE, DoctorView Dr,SpecializationView spec)
        {
            InitializeComponent();
            this.DataContext = this;

            Prioritet.SelectedIndex = 0;
            SelektovaniDoktor = Dr;
            Dstart = DatumS;
            Dend = DatumE;
            Selektovan = spec;
        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            String priority = "";
            if (Prioritet.SelectedIndex == 0)
            {
                priority = "Doctor";

            }
            else if (Prioritet.SelectedIndex == 1) {

                priority = "DateRange";
            }

           // SearchController _searchController = new SearchController();
            //SearchedRooms = new ObservableCollection<WorkDayViewView>(WorkDayConverter.DoctorWorkDayToDoctorWorkDayDto(_searchController.SearchDoctorsRooms(search.Text.ToString()).ToList()));
            ResultSchedule s = new ResultSchedule(Dstart, Dend, SelektovaniDoktor, priority);
            s.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Doctors s = new Doctors(Dstart, Dend, Selektovan);
            s.Show();
            this.Close();
        }
    }
}
