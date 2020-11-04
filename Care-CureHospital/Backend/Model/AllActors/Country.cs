/***********************************************************************
 * Module:  State.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.State
 ***********************************************************************/

using System;

namespace Model.AllActors
{
    public class Country
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }

        public Country()
        {
        }

        public Country(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }

        public Country(string name)
        {
            this.Name = name;
        }

    }
}