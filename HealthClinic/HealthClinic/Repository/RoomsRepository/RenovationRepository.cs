/***********************************************************************
 * Module:  RenovationRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.RenovationRepository
 ***********************************************************************/

using Model.Term;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.RoomsRepository
{
    public class RenovationRepository : CSVRepository<Renovation, int>, IRenovationRepository
    {
        private const string RENOVATION_FILE = "../../Resources/Data/renovation.csv";
        private static RenovationRepository instance;

        public static RenovationRepository Instance()
        {
            if (instance == null)
            {
                instance = new RenovationRepository(
               new CSVStream<Renovation>(RENOVATION_FILE, new RenovationCSVConverter(",")),
               new IntSequencer());
            }
            return instance;
        }

        public RenovationRepository(ICSVStream<Renovation> stream, ISequencer<int> sequencer)
           : base(stream, sequencer)
        {
        }

        /*public Room AddEntity(Room entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Room entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Room entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Renovation> IRepository<Renovation, int>.GetAllEntities()
        {
            throw new NotImplementedException();
        }

        Renovation IRepository<Renovation, int>.GetEntity(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}