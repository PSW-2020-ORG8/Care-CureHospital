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
        public String RoomId { get; set; }
        public int TypeOfRoomId { get; set; }
        public virtual TypeOfRoom TypeOfRoom { get; set; }
        public virtual List<InventaryRoom> Equipment { get; set; }
      
        public Room(int id)
        {
            this.Id = id;
        }

        public Room()
        {
        }

        public Room(int id, string roomID, TypeOfRoom typeOfRoom, DateTime fromDateTime, DateTime toDateTime, List<InventaryRoom> equipment) : base(fromDateTime, toDateTime)
        {
            this.RoomId = roomID;
            this.Id = id;            
            this.TypeOfRoom = typeOfRoom;
            this.Equipment = equipment;         
        }

        public Room(string roomID, TypeOfRoom typeOfRoom, List<InventaryRoom> equipment)
        {
            this.RoomId = roomID;
            this.TypeOfRoom = typeOfRoom;
            this.Equipment = equipment;
        }

        public Room(int id, string roomID, int typeOfRoomID, List<InventaryRoom> equipment) : this(id)
        {
            RoomId = roomID;
            this.TypeOfRoomId = typeOfRoomID;
            Equipment = equipment;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}