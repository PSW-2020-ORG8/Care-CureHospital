using HospitalMap.WPF.ModelWPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace HospitalMap.Repository
{
    public class InformationEditRepository
    {
        private const String _path = @"./../../../Code/Resources/RoomsInformation.txt";

        private static InformationEditRepository _instance = null;

        public static InformationEditRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InformationEditRepository();
            }
            return _instance;
        }

        public ObservableCollection<RoomInformationWiev> rooms
        {
            get;
            set;

        }

        public InformationEditRepository()
        {
            
            rooms = GetAll();



        }

        public ObservableCollection<RoomInformationWiev> GetAll()
        {
            String text = "";

            if (File.Exists(_path))
                text = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<ObservableCollection<RoomInformationWiev>>(text);

        }

        public void SaveAll(ObservableCollection<RoomInformationWiev> rooms)
        {
            string json = JsonConvert.SerializeObject(rooms, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(_path, json);
        }


        public void Edit(RoomInformationWiev room)
        {
            foreach(RoomInformationWiev currentRoom in rooms)
            {
                if (currentRoom.NameOfRoom.Equals(room.NameOfRoom.ToString())){
                    currentRoom.NumberOfFloor = room.NumberOfFloor;
                    currentRoom.NameOfClinic = room.NameOfClinic;
                    currentRoom.BedCapacity = room.BedCapacity;
                    currentRoom.AvailableBeds = room.AvailableBeds;
                    currentRoom.OccupiedBeds = room.OccupiedBeds;
                }
            }
            SaveAll(rooms);
        }

        public RoomInformationWiev GetById(string room)
        {
            foreach (RoomInformationWiev currentRoom in rooms)
            {
                if (currentRoom.NameOfRoom.Equals(room.ToString()))
                {
                    return currentRoom;
                }
            }
            return null;
        }


    }
}
