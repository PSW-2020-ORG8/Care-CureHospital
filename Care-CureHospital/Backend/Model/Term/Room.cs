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
        public int id { get; set; }
        public String RoomID { get; set; }
        public int typeOfRoomID { get; set; }
        public virtual TypeOfRoom TypeOfRoom { get; set; }
        public virtual List<InventaryRoom> Equipment { get; set; }
      
        public Room(int id)
        {
            this.id = id;
        }

        public Room()
        {
        }

        public Room(int id, string roomID, TypeOfRoom typeOfRoom, DateTime fromDateTime, DateTime toDateTime, List<InventaryRoom> equipment) : base(fromDateTime, toDateTime)
        {
            this.RoomID = roomID;
            this.id = id;            
            this.TypeOfRoom = typeOfRoom;
            this.Equipment = equipment;         
        }

        public Room(string roomID, TypeOfRoom typeOfRoom, List<InventaryRoom> equipment)
        {
            this.RoomID = roomID;
            this.TypeOfRoom = typeOfRoom;
            this.Equipment = equipment;
        }

        public Room(int id, string roomID, int typeOfRoomID, List<InventaryRoom> equipment) : this(id)
        {
            RoomID = roomID;
            this.typeOfRoomID = typeOfRoomID;
            Equipment = equipment;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
    }
}