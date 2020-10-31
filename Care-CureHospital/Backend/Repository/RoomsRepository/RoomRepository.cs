/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
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
   public class RoomRepository : CSVRepository<Room,int>, IRoomRepository
   {
        private const string ROOM_FILE = "../../Resources/Data/room.csv";
        private static RoomRepository instance;

        public static RoomRepository Instance()
        {
            if (instance == null)
            {
                instance = new RoomRepository(
               new CSVStream<Room>(ROOM_FILE, new RoomCSVConverter(",")),
               new IntSequencer());
            }
            return instance;
        }

        public RoomRepository(ICSVStream<Room> stream, ISequencer<int> sequencer)
          : base(stream, sequencer)
        {
        }

    }
}