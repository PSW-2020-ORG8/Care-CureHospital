using HospitalMap.Code.Repository.DoctorsRepository;
using HospitalMap.Code.Repository.RoomInformatioRepository;
using HospitalMap.Repository;
using HospitalMap.WPF;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalMap.Service
{
    public class InformationEditService
    {

        private InformationEditRepository _informationEditRepository;
        private DoctorsRoomRepository _doctorsRoomRepositoryRepository;
        private RoomWorkTimeRepository _roomWorkTimeRepository;
        private ObservableCollection<DoctorRoomView> _allDoctors;

        public InformationEditService()
        {
            _informationEditRepository = InformationEditRepository.GetInstance();
            _doctorsRoomRepositoryRepository = DoctorsRoomRepository.GetInstance();
            _roomWorkTimeRepository = RoomWorkTimeRepository.GetInstance();
            _allDoctors = _doctorsRoomRepositoryRepository.GetAll();
        }





        public void EditInformation(RoomInformationVieW room)
        {
            _informationEditRepository.Edit(room);
        }

        public RoomInformationVieW GetRoomById(string roomId)
        {
            return _informationEditRepository.GetById(roomId);
        }

        public DoctorRoomView GetDoctorsRoomById(string roomId)
        {
            return _doctorsRoomRepositoryRepository.GetById(roomId);
           
        }

        public void AddNewDoctorOnInformation(DoctorRoomView currentDoctorsRoom, string newDoctorsJmbg)
        {

            DoctorRoomView _newDoctorRoomView = _doctorsRoomRepositoryRepository.GetByJmbg(newDoctorsJmbg);

            foreach (DoctorRoomView doctor in _allDoctors)
            {
                if (doctor.IdOfRoom.Equals(currentDoctorsRoom.IdOfRoom.ToString()))
                {
                    doctor.NameOfClinic = _newDoctorRoomView.NameOfClinic;
                    doctor.NumberOfFloor = _newDoctorRoomView.NumberOfFloor;
                    doctor.NameOfDoctor = _newDoctorRoomView.NameOfDoctor;
                    doctor.SurnameOfDoctor = _newDoctorRoomView.SurnameOfDoctor;
                    doctor.JmbgOfDoctor = _newDoctorRoomView.JmbgOfDoctor;
                    doctor.FromDateTime = _newDoctorRoomView.FromDateTime;
                    doctor.ToDateTime = _newDoctorRoomView.ToDateTime;
                }
            }
            _doctorsRoomRepositoryRepository.SaveAll(_allDoctors);
        }


        public void EditCurrentDoctorOnInformation(DoctorRoomView selectedDoctorOnRoom)
        {
            foreach (DoctorRoomView doctor in _allDoctors)
            {
                if (doctor.IdOfRoom.Equals(selectedDoctorOnRoom.IdOfRoom.ToString()))
                {
                    doctor.NumberOfFloor = selectedDoctorOnRoom.NumberOfFloor;
                    doctor.NameOfClinic = selectedDoctorOnRoom.NameOfClinic;
                    doctor.NameOfDoctor = selectedDoctorOnRoom.NameOfDoctor;
                    doctor.SurnameOfDoctor = selectedDoctorOnRoom.SurnameOfDoctor;
                    doctor.FromDateTime = selectedDoctorOnRoom.FromDateTime;
                    doctor.ToDateTime = selectedDoctorOnRoom.ToDateTime;
                }
            }
            _doctorsRoomRepositoryRepository.SaveAll(_allDoctors);
        }

        public WorkTimeViewModel GetWorkTimeByRoom(string roomId)
        {
            return _roomWorkTimeRepository.GetById(roomId);
        }



        public void EditWorkTimeByRoom(WorkTimeViewModel workTime)
        {
            _roomWorkTimeRepository.Edit(workTime);
        }


    }
}
