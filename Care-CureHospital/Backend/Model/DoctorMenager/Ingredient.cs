/***********************************************************************
 * Module:  Ingredient.cs
 * Author:  Stefan
 * Purpose: Definition of the Class DoctorMenager.Ingredient
 ***********************************************************************/

using System;

namespace Model.DoctorMenager
{
    public class Ingredient
    {
        public String Name { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(string name)
        {
            this.Name = name;
        }

        
    }
}