/***********************************************************************
 * Module:  Soba.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.Soba
 ***********************************************************************/

using Model.Manager;
using HealthClinic.Repository;
using System;
using System.Collections.Generic;


namespace Model.Term
{
    public class Room : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public int TypeOfRoomId { get; set; }
        public virtual TypeOfRoom TypeOfRoom { get; set; }
        public virtual List<InventaryRoom> Equipment { get; set; }
      
        public Room(int id)
        {
            Id = id;
        }

        public Room()
        {
        }

        public Room(int id, string roomID, TypeOfRoom typeOfRoom, DateTime fromDateTime, DateTime toDateTime, List<InventaryRoom> equipment) : base(fromDateTime, toDateTime)
        {
            RoomId = roomID;
            Id = id;            
            TypeOfRoom = typeOfRoom;
            Equipment = equipment;         
        }

        public Room(string roomID, TypeOfRoom typeOfRoom, List<InventaryRoom> equipment)
        {
            RoomId = roomID;
            TypeOfRoom = typeOfRoom;
            Equipment = equipment;
        }

        public Room(int id, string roomID, int typeOfRoomID, List<InventaryRoom> equipment) : this(id)
        {
            RoomId = roomID;
            TypeOfRoomId = typeOfRoomID;
            Equipment = equipment;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}