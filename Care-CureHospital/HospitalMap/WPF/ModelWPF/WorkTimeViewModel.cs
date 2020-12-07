using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class WorkTimeViewModel : INotifyPropertyChanged
    {


        


        public WorkTimeViewModel() { }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        private string _nameOfClinic;

        public string NameOfClinic
        {
            get
            {
                return _nameOfClinic;
            }
            set
            {
                if (value != _nameOfClinic)
                {
                    _nameOfClinic = value;
                    OnPropertyChanged("NameOfClinic");
                }
            }
        }





        private string _numberOfFloor;
        public string NumberOfFloor
        {
            get
            {
                return _numberOfFloor;
            }
            set
            {
                if (value != _numberOfFloor)
                {
                    _numberOfFloor = value;
                    OnPropertyChanged("NumberOfFloor");
                }
            }
        }




        private string _idOfRoom;

        public string IdOfRoom
        {
            get
            {
                return _idOfRoom;
            }
            set
            {
                if (value != _idOfRoom)
                {
                    _idOfRoom = value;
                    OnPropertyChanged("IdOfRoom");
                }
            }
        }




        private string _nameOfRoom;
        public string NameOfRoom
        {
            get
            {
                return _nameOfRoom;
            }
            set
            {
                if (value != _nameOfRoom)
                {
                    _nameOfRoom = value;
                    OnPropertyChanged("NameOfRoom");
                }
            }
        }








        private string _fromDateTime;

        public string FromDateTime
        {
            get
            {
                return _fromDateTime;
            }
            set
           {
                if (value != _fromDateTime)
                {
                    _fromDateTime = value;
                    OnPropertyChanged("FromDateTime");
                }
            }
        }



        private string _toDateTime;

        public string ToDateTime
        {
            get
            {
                return _toDateTime;
            }
            set
            {
                if (value != _toDateTime)
                {
                    _toDateTime = value;
                    OnPropertyChanged("ToDateTime");
                }
            }
        }



    }
}
