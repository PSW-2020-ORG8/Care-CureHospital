using Model.Term;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class WorkDayViewView : INotifyPropertyChanged
    {

        private Appointment _ime;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string IdOfRoom { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public string Specialization { get; set; }
        public string DoctorFullName { get; set; }

        public Appointment AvailableAppointment
        {
            get { return _ime; }
            set { _ime = value; OnPropertyChanged("AvailableAppointment"); }
        }

    }
}
