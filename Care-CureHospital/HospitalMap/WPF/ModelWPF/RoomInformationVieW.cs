using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HospitalMap.WPF.ModelWPF
{
    public class RoomInformationVieW : INotifyPropertyChanged
    {

        public RoomInformationVieW() { }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        private string _idOfRoom;
        private string _nameOfRoom;
        private string _nameOfClinic;
        private string _numberOfFloor;
        private string _bedCapacity;
        private string _availableBeds;
        private string _occupiedBeds;

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
