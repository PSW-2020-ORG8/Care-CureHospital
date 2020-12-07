using HospitalMap.Code.Repository.DoctorsRepository;
using HospitalMap.Code.Repository.RoomInformatioRepository;
using HospitalMap.Repository;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalMap.Code.Service
{
    public class SearchService
    {

        private InformationEditRepository _informationEditRepository;
        private DoctorsRoomRepository _doctorsRoomRepository;
        private RoomWorkTimeRepository _roomWorkTimeRepository;
        

        public SearchService()
        {
            _informationEditRepository = InformationEditRepository.GetInstance();
            _doctorsRoomRepository = DoctorsRoomRepository.GetInstance();
            _roomWorkTimeRepository = RoomWorkTimeRepository.GetInstance();
            
        }



        public ObservableCollection<RoomInformationVieW> SearchPatientsRooms(string nameOfRoom)
        {
            ObservableCollection<RoomInformationVieW> searchedRooms = new ObservableCollection<RoomInformationVieW>();

            foreach (RoomInformationVieW currentRoom in _informationEditRepository.GetAll())
            {
                if (currentRoom.NameOfRoom.Contains(nameOfRoom))
                {
                    searchedRooms.Add(currentRoom);
                }


            }
         
            return searchedRooms;
        }



        public ObservableCollection<DoctorRoomView> SearchDoctorsRooms(string nameOfRoom)
        {
            ObservableCollection<DoctorRoomView> searchedRooms = new ObservableCollection<DoctorRoomView>();

            foreach (DoctorRoomView currentRoom in _doctorsRoomRepository.GetAll())
            {
                if (currentRoom.NameOfRoom.Contains(nameOfRoom))
                {
                    searchedRooms.Add(currentRoom);
                }


            }

            return searchedRooms;

        }


        public ObservableCollection<WorkTimeViewModel> SearchAnotherRooms(string nameOfRoom)
        {
            ObservableCollection<WorkTimeViewModel> searchedRooms = new ObservableCollection<WorkTimeViewModel>();

            foreach (WorkTimeViewModel currentRoom in _roomWorkTimeRepository.GetAll())
            {
                if (currentRoom.NameOfRoom.Contains(nameOfRoom))
                {
                    searchedRooms.Add(currentRoom);
                }


            }

            return searchedRooms;

        }



    }
}
