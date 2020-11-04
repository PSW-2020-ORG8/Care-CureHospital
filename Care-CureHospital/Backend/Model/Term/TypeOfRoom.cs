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
        public String NameOfType { get; set; }

        public TypeOfRoom()
        {
        }

        public TypeOfRoom(string nameOfType)
        {
            this.NameOfType = nameOfType;
        }

        
    }
}