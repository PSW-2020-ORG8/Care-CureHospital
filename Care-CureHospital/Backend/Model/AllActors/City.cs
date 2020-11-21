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
        public int Id { get; set; }
        public String Name { get; set; }
        public int PostCode { get; set; }
        public String Adress { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public City()
        {
        }

        public City(string name, string adress, Country country)
        {
            this.Name = name;
            this.Adress = adress;
            this.CountryId = country.Id;
            this.Country = country;
        }

        public City(string name, int postCode, string adress, Country country)
        {
            this.Name = name;
            this.PostCode = postCode;
            this.Adress = adress;
            this.CountryId = country.Id;
            this.Country = country;
        }

    }
}