using DocumentsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class Room : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string RoomId { get; set; }

        public Room(string roomId)
        {
            RoomId = roomId;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
