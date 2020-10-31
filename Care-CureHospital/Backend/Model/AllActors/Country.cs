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
        private String name;
        private String code;

        public string Name { get => name; set => name = value; }
        public string Code { get => code; set => code = value; }

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