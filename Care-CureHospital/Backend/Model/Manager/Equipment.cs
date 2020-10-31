/***********************************************************************
 * Module:  Equipment.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Manager.Equipment
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Manager
{
    public class Equipment : IIdentifiable<int>
    {
        private int id;
        private String code;
        private String name;
        private String typeOfEquipment;
        private int amount;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string TypeOfEquipment { get => typeOfEquipment; set => typeOfEquipment = value; }
        public int Amount { get => amount; set => amount = value; }

        public Equipment(int id)
        {
            this.id = id;
        }

        public Equipment()
        {
        }

        public Equipment(int id, string code, string name, string typeOfEquipment, int amount)
        {
            this.Code = code;
            this.Name = name;
            this.TypeOfEquipment = typeOfEquipment;
            this.Amount = amount;
            this.id = id;
        }

        public Equipment(string code, string name, string typeOfEquipment, int amount)
        {
            this.Code = code;
            this.Name = name;
            this.TypeOfEquipment = typeOfEquipment;
            this.Amount = amount;
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