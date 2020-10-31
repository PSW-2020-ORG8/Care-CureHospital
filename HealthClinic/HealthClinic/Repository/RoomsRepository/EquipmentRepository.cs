/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using Model.Manager;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.RoomsRepository
{
    public class EquipmentRepository : CSVRepository<Equipment, int>, IEquipmentRepository
    {
        private const string EQUIPMENT_FILE = "../../Resources/Data/equipment.csv";
        private static EquipmentRepository instance;

        public static EquipmentRepository Instance()
        {
            if (instance == null)
            {
                instance = new EquipmentRepository(
               new CSVStream<Equipment>(EQUIPMENT_FILE, new EquipmentCSVConverter(",")),
               new IntSequencer());
            }
            return instance;
        }

        public EquipmentRepository(ICSVStream<Equipment> stream, ISequencer<int> sequencer)
           : base(stream, sequencer)
        {
        }

    }
}