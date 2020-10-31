/***********************************************************************
 * Module:  Soba.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.Soba
 ***********************************************************************/

using Model.Manager;
using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.Term
{
    public class Room : Term, IIdentifiable<int>
    {
        private int id;
        private String roomID;
        private TypeOfRoom typeOfRoom;
        private List<InventaryRoom> equipment;

        public string RoomID { get => roomID; set => roomID = value; }
        public TypeOfRoom TypeOfRoom { get => typeOfRoom; set => typeOfRoom = value; }
        public List<InventaryRoom> Equipment { get => equipment; set => equipment = value; }
      
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