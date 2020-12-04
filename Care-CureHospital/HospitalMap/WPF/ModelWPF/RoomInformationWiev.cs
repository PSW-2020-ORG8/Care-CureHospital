using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class RoomInformationWiev : INotifyPropertyChanged
    {

        public RoomInformationWiev() { }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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



        private string _bedCapacity;
        


        public string BedCapacity
        {
            get
            {
                return _bedCapacity;
            }
            set
            {
                if (value != _numberOfFloor)
                {
                    _bedCapacity = value;
                    OnPropertyChanged(" BedCapacity");
                }
            }
        }





        private string _availableBeds;
        

        public string AvailableBeds
        {
            get
            {
                return _availableBeds;
            }
            set
            {
                if (value != _availableBeds)
                {
                    _availableBeds = value;
                    OnPropertyChanged("AvailableBeds");
                }
            }
        }




        private string _occupiedBeds;
        
        public string OccupiedBeds
        {
            get
            {
                return _occupiedBeds;
            }
            set
            {
                if (value != _occupiedBeds)
                {
                    _occupiedBeds = value;
                    OnPropertyChanged("OccupiedBeds");
                }
            }
        }


    }
}
