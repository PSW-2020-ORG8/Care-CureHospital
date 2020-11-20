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
        public int id { get; set; }
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
            this.id = id;
            NameOfType = nameOfType;
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