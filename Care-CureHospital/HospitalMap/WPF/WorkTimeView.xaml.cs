using HospitalMap.Controller;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for WorkTimeView.xaml
    /// </summary>
    public partial class WorkTimeView : Window
    {


        public WorkTimeViewModel WorkTimeVie
        {
            get;
            set;
        }

        private InformationEditController _informationControler;

        public WorkTimeView(string id)
        {
            InitializeComponent();

            this.DataContext = this;
            _informationControler = new InformationEditController();

            if (Login.role != 3)
            {


                ButtonSave.Visibility = Visibility.Hidden;

                FromTXT.IsEnabled = false;
                ToTXT.IsEnabled = false;



            }

            if (id.Equals("HospitalA") || id.Equals("HospitalB"))
            {
                NameOfClinicTxtBlock.Visibility = Visibility.Hidden;
                NumberOfFloorTxtBlock.Visibility = Visibility.Hidden;
                NameOfClinicTxt.Visibility = Visibility.Hidden;
                NumberOfFloorTxt.Visibility = Visibility.Hidden;

            }

            WorkTimeVie = _informationControler.GetWorkTimeByRoom(id);
           
            


        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            int from = Int32.Parse(WorkTimeVie.FromDateTime);
            int to = Int32.Parse(WorkTimeVie.ToDateTime);

            if (from >= to)
            {
                MessageBox.Show("The initial hourly rate must be less than the final hourly rate! ", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            _informationControler.EditWorkTimeByRoom(WorkTimeVie);
            this.Close();
        }
    }
}
