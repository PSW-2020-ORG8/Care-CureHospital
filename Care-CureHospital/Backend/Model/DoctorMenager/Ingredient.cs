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
        private String name;
        public string Name { get => name; set => name = value; }

        public Ingredient()
        {
        }

        public Ingredient(string name)
        {
            this.Name = name;
        }

        
    }
}