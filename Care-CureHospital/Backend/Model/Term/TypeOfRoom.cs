/***********************************************************************
 * Module:  TypeOfRoom.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.TypeOfRoom
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Term
{
    public class TypeOfRoom : IIdentifiable<int>
    {
        public int Id { get; set; }
        public String NameOfType { get; set; }

        public TypeOfRoom()
        {
        }

        public TypeOfRoom(string nameOfType)
        {
            this.NameOfType = nameOfType;
        }

        public TypeOfRoom(int id, string nameOfType)
        {
            this.Id = id;
            NameOfType = nameOfType;
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