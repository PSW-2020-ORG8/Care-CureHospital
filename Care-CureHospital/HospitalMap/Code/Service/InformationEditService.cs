using HospitalMap.Repository;
using HospitalMap.WPF.ModelWPF;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.Service
{
    public class InformationEditService
    {

        private InformationEditRepository _informationEditRepository;

        public InformationEditService()
        {
            _informationEditRepository = InformationEditRepository.GetInstance();
        }





        public void EditInformation(RoomInformationWiev room)
        {
            _informationEditRepository.Edit(room);
        }

        public RoomInformationWiev GetRoomById(string room)
        {
            return _informationEditRepository.GetById(room);
        }




    }
}
