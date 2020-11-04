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
        public int id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String TypeOfEquipment { get; set; }
        public int Amount { get; set; }

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