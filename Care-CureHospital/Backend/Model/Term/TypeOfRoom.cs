/***********************************************************************
 * Module:  TypeOfRoom.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.TypeOfRoom
 ***********************************************************************/

using System;

namespace Model.Term
{
    public class TypeOfRoom
    {
        private String nameOfType;

        public string NameOfType { get => nameOfType; set => nameOfType = value; }

        public TypeOfRoom()
        {
        }

        public TypeOfRoom(string nameOfType)
        {
            this.NameOfType = nameOfType;
        }

        
    }
}