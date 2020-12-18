using HospitalMap.WPF.Converter;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for Specialization.xaml
    /// </summary>
    public partial class Specialization : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public static SpecializationView Selektovan
        {
            get;
            set;
        }

        private ObservableCollection<SpecializationView> _specs;
        public ObservableCollection<SpecializationView> VrsteSpec
        {
            get { return _specs; }
            set
            {
                _specs = value; OnPropertyChanged("VrsteSpec");

            }
        }

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

        public Specialization()
        {
            InitializeComponent();
            this.DataContext = this;

            VrsteSpec = new ObservableCollection<SpecializationView>();
            Backend.App.Instance().SpetialitationService.GetAllEntities().ToList().ForEach(specialization => VrsteSpec.Add(SpecializationConverter.SpecializationToSpecializationDto(specialization)));
            Selektovan=VrsteSpec[0];
        }

        public Specialization(DateTime DatumS,DateTime DatumE)
        {
            InitializeComponent();
            this.DataContext = this;

            VrsteSpec = new ObservableCollection<SpecializationView>();
            Backend.App.Instance().SpetialitationService.GetAllEntities().ToList().ForEach(specialization => VrsteSpec.Add(SpecializationConverter.SpecializationToSpecializationDto(specialization)));
            Dstart = DatumS;
            Dend = DatumE;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Doctors s = new Doctors(Dstart, Dend, Selektovan);
            s.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Schedule s = new Schedule();
            s.Show();
            this.Close();
        }
    }
}
