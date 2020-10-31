/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model.Term;
using Model.Manager;
using Repository.RoomsRepository;

namespace Service.RoomsServices
{
    public class RoomService : IService<Room, int>
    {
        public IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public List<Room> GetAllRoomForMedicalExamination()
        {
            List<Room> medicalExaminationRooms = new List<Room>();
            foreach (Room room in roomRepository.GetAllEntities())
                if (room.TypeOfRoom.NameOfType.Equals("Soba za preglede"))
                    medicalExaminationRooms.Add(room);
            return medicalExaminationRooms;
        }

        public bool RoomWithRoomIDExist(String roomID)
        {
            foreach (Room room in roomRepository.GetAllEntities())
                if (room.RoomID.Equals(roomID))
                    return true;
            return false;
        }

        public void DetermineTypeOfRoom(TypeOfRoom typeOfRoom, String roomID)
        {
            foreach (Room room in roomRepository.GetAllEntities())
                if (room.RoomID.Equals(roomID))
                {
                    room.TypeOfRoom = typeOfRoom;
                    break;
                }                   
        }

        public void AddEquipmentInRoom(InventaryRoom equipment, String roomID)
        {
            foreach (Room room in roomRepository.GetAllEntities())
                if (room.RoomID == roomID)
                    room.Equipment.Add(equipment);        
        }

        public List<InventaryRoom> GetEquipmentForRoom(Room room) 
        {
            foreach (Room oneRoom in roomRepository.GetAllEntities())
                if (oneRoom.RoomID == room.RoomID)
                    return oneRoom.Equipment;
            return null;
        }

        public Room GetRoomByRoomID(String roomID)
        {
            foreach (Room oneRoom in roomRepository.GetAllEntities())
                if (oneRoom.RoomID == roomID)
                    return oneRoom;
            return null;
        }

        public List<Room> GetAllFreeRoomsByDateTime(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Boolean GetOccupancyStatus(Room room, DateTime time)
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastTermForRoom(Room room)
        {
            return room.ToDateTime;
        }

        public Room GetEntity(int id)
        {
            return roomRepository.GetEntity(id);
        }

        public IEnumerable<Room> GetAllEntities()
        {
            return roomRepository.GetAllEntities();
        }
       
        public Room AddEntity(Room entity)
        {
            return roomRepository.AddEntity(entity);
        }

        public void UpdateEntity(Room entity)
        {
            roomRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Room entity)
        {
            roomRepository.UpdateEntity(entity);
        }

        public Room GetFirstRoom(List<Room> rooms) 
        {
            foreach (Room room in rooms)
                return room;
            return null;
        }
    }
}