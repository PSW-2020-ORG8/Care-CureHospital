/***********************************************************************
 * Module:  City.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.City
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.AllActors
{
    public class City
    {
        private String name;
        private int postCode;
        private String adress;
        private Country country;

        public string Name { get => name; set => name = value; }
        public int PostCode { get => postCode; set => postCode = value; }
        public string Adress { get => adress; set => adress = value; }
        public Country Country { get => country; set => country = value; }

        public City()
        {
        }

        public City(string name, string adress, Country country)
        {
            this.Name = name;
            this.Adress = adress;
            this.Country = country;
        }

        public City(string name, int postCode, string adress, Country country)
        {
            this.Name = name;
            this.PostCode = postCode;
            this.Adress = adress;
            this.Country = country;
        }

    }
}