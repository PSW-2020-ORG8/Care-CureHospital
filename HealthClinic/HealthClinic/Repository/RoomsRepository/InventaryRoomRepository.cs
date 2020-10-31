using Model.Manager;
using Repository.CSV.Converter;
using Repository.Csv;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RoomsRepository
{
    public class InventaryRoomRepository : CSVRepository<InventaryRoom, int>, IInventaryRoomRepository
    {
        private const string INVENTARY_FILE = "../../Resources/Data/inventaryRoom.csv";
        private static InventaryRoomRepository instance;

        public static InventaryRoomRepository Instance()
        {
            if (instance == null)
            {
                instance = new InventaryRoomRepository(
               new CSVStream<InventaryRoom>(INVENTARY_FILE, new InventaryRoomCSVConverter(",")),
               new IntSequencer());
            }
            return instance;
        }

        public InventaryRoomRepository(ICSVStream<InventaryRoom> stream, ISequencer<int> sequencer)
           : base(stream, sequencer)
        {
        }

    }
}
