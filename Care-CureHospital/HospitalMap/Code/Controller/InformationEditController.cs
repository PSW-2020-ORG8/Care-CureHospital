using HospitalMap.Service;
using HospitalMap.WPF;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.Controller
{
    public class InformationEditController
    {


        private InformationEditService _informationEditService;
        

        public InformationEditController() {

            _informationEditService = new InformationEditService();
             }

         public void  EditInformation(RoomInformationVieW room)
        {
             _informationEditService.EditInformation(room);
        }

        public RoomInformationVieW GetRoomById(string roomId)
        {
            return _informationEditService.GetRoomById(roomId);
        }


        public DoctorRoomView GetDoctorsRoomById(string roomId)
        {
            return _informationEditService.GetDoctorsRoomById(roomId);
        }


        public void AddNewDoctorOnInformation(DoctorRoomView currentDoctorsRoom,string newDoctorsJmbg)
        {
            _informationEditService.AddNewDoctorOnInformation(currentDoctorsRoom,newDoctorsJmbg);
        }

        public void EditCurrentDoctorOnInformation(DoctorRoomView doctorsRoom)
        {
            _informationEditService.EditCurrentDoctorOnInformation(doctorsRoom);
        }


        public WorkTimeViewModel GetWorkTimeByRoom(string roomId)
        {
            return _informationEditService.GetWorkTimeByRoom(roomId);
        }


        public void EditWorkTimeByRoom(WorkTimeViewModel workTime)
        {
            _informationEditService.EditWorkTimeByRoom(workTime);
        }

    }
}
