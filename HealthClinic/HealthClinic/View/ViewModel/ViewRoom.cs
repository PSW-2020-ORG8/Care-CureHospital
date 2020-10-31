using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.ViewModel
{
    public class ViewRoom : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        private String roomID;
        private String typeOfRoom;
        private String equipment;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }
        public String RoomID
        {
            get { return roomID; }
            set
            {
                if (roomID != value)
                {
                    roomID = value;
                    OnPropertyChanged();
                }
            }
        }
        public String TypeOfRoom
        {
            get { return typeOfRoom; }
            set
            {
                if (typeOfRoom != value)
                {
                    typeOfRoom = value;
                    OnPropertyChanged();
                }
            }
        }
        public String Equipment
        {
            get { return equipment; }
            set
            {
                if (equipment != value)
                {
                    equipment = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
