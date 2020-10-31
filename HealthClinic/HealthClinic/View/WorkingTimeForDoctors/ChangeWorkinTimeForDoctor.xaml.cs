using Controller.UsersControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
using Model.AllActors;
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
    /// Interaction logic for ChangeWorkinTimeForDoctor.xaml
    /// </summary>
    public partial class ChangeWorkinTimeForDoctor : Window
    {
        private readonly WorkingTimeForDoctorController workingTimeForDoctorController;
        private readonly UserController userController;

        public static ObservableCollection<Doctor> DoctorsView { get; set; }

        public ChangeWorkinTimeForDoctor()
        {
            InitializeComponent();
            this.DataContext = this;
            TimePickerStartWorkingTime.SelectedTime = DateTime.Now.Date;
            TimePickerEndWorkingTime.SelectedTime = DateTime.Now.Date;


            var app = Application.Current as App;
            workingTimeForDoctorController = app.WorkingTimeForDoctorController;
            userController = app.UserController;

            DoctorsView = new ObservableCollection<Doctor>(userController.GetAllDoctors());
            
        }

        private void Button_Click_Potvrdi(object sender, RoutedEventArgs e)
        {
            Doctor selectedDoctor = (Doctor)ComboBoxDoctors.SelectedItem;
            String selectedDay = ComboBoxDaysOfTheWeek.SelectedItem.ToString().Substring(38);
            DateTime startWorkingTime = DateTime.Parse(TimePickerStartWorkingTime.SelectedTime.ToString());
            DateTime endWorkingTime = DateTime.Parse(TimePickerEndWorkingTime.SelectedTime.ToString());
            bool doctorDoesntWork = CheckBoxDoctorDontWork.IsChecked == true;

            WorkingTimeForDoctor workingTimeForDoctorForOneDay = null;

            if (selectedDay.Equals("Ponedeljak"))
            {
                workingTimeForDoctorForOneDay = workingTimeForDoctorController.GetWorkTimeForDoctorByDoctorAndDay(selectedDoctor, DayOfWeek.Monday); 
                ChangeWorkTime(workingTimeForDoctorForOneDay, doctorDoesntWork, startWorkingTime, endWorkingTime);               
            }
            else if (selectedDay.Equals("Utorak"))
            {
                workingTimeForDoctorForOneDay = workingTimeForDoctorController.GetWorkTimeForDoctorByDoctorAndDay(selectedDoctor, DayOfWeek.Tuesday); 
                ChangeWorkTime(workingTimeForDoctorForOneDay, doctorDoesntWork, startWorkingTime, endWorkingTime);
            }
            else if (selectedDay.Equals("Sreda"))
            {
                workingTimeForDoctorForOneDay = workingTimeForDoctorController.GetWorkTimeForDoctorByDoctorAndDay(selectedDoctor, DayOfWeek.Wednesday); 
                ChangeWorkTime(workingTimeForDoctorForOneDay, doctorDoesntWork, startWorkingTime, endWorkingTime);
            }
            else if (selectedDay.Equals("Četvrtak"))
            {
                workingTimeForDoctorForOneDay = workingTimeForDoctorController.GetWorkTimeForDoctorByDoctorAndDay(selectedDoctor, DayOfWeek.Thursday);
                ChangeWorkTime(workingTimeForDoctorForOneDay, doctorDoesntWork, startWorkingTime, endWorkingTime);
            }
            else if (selectedDay.Equals("Petak"))
            {
                workingTimeForDoctorForOneDay = workingTimeForDoctorController.GetWorkTimeForDoctorByDoctorAndDay(selectedDoctor, DayOfWeek.Friday);
                ChangeWorkTime(workingTimeForDoctorForOneDay, doctorDoesntWork, startWorkingTime, endWorkingTime);
            }
            else if (selectedDay.Equals("Subota"))
            {
                workingTimeForDoctorForOneDay = workingTimeForDoctorController.GetWorkTimeForDoctorByDoctorAndDay(selectedDoctor, DayOfWeek.Saturday);
                ChangeWorkTime(workingTimeForDoctorForOneDay, doctorDoesntWork, startWorkingTime, endWorkingTime);
            }
            else if (selectedDay.Equals("Nedelja"))
            {
                workingTimeForDoctorForOneDay = workingTimeForDoctorController.GetWorkTimeForDoctorByDoctorAndDay(selectedDoctor, DayOfWeek.Sunday);
                ChangeWorkTime(workingTimeForDoctorForOneDay, doctorDoesntWork, startWorkingTime, endWorkingTime);
            }           
        }

        private void ChangeWorkTime(WorkingTimeForDoctor workingTimeForDoctorForOneDay,bool doctorDoesntWork,
            DateTime startWorkingTime, DateTime endWorkingTime)
        {
            if (doctorDoesntWork)
            {
                DoctorDoesntWork(workingTimeForDoctorForOneDay);
                return;
            }
            workingTimeForDoctorForOneDay.DoesWork = true;
            workingTimeForDoctorForOneDay.FromDateTime = startWorkingTime;
            workingTimeForDoctorForOneDay.ToDateTime = endWorkingTime;
            AddToDataGridView(workingTimeForDoctorForOneDay);
            workingTimeForDoctorController.UpdateEntity(workingTimeForDoctorForOneDay);
            this.Close();
            MessageBox.Show("Uspešno ste promenili radno vreme lekara", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DoctorDoesntWork(WorkingTimeForDoctor workingTimeForDoctorForOneDay) 
        {
            workingTimeForDoctorForOneDay.DoesWork = false;
            AddToDataGridView(workingTimeForDoctorForOneDay);
            workingTimeForDoctorController.UpdateEntity(workingTimeForDoctorForOneDay);
            this.Close();
            MessageBox.Show("Uspešno ste promenili radno vreme lekara", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddToDataGridView(WorkingTimeForDoctor workingTime)
        {
            foreach (ViewWorkingTimeForDoctor workingTimeView in WorkingTimeForDoctors.WorkingTimeForDoctorView)
                if (workingTimeView.Id == workingTime.GetId())
                    if (workingTime.DoesWork == false)
                        workingTimeView.WorkingTime = "Ne radi";
                    else
                        workingTimeView.WorkingTime = workingTime.FromDateTime.ToString("HH:mm") + " - " + workingTime.ToDateTime.ToString("HH:mm");                    
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
