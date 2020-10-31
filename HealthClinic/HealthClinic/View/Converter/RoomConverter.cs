using HealthClinic.View.ViewModel;
using Model.Manager;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class RoomConverter : AbstractConverter
    {
        public static ViewRoom ConvertRoomToRoomView(Room room)
        {
            return new ViewRoom
            {
                Id = room.GetId(),
                RoomID = room.RoomID,
                TypeOfRoom = room.TypeOfRoom.NameOfType,
                Equipment = EquipmentToString(room.Equipment)
            };
        }

        public static IList<ViewRoom> ConvertRoomListToRoomtViewList(IList<Room> rooms)
            => ConvertEntityListToViewList(rooms, ConvertRoomToRoomView);

        private static String EquipmentToString(List<InventaryRoom> equipmentInRoom)
        {
            String ret = "";
            if (equipmentInRoom.Count != 0)
            {
                foreach (InventaryRoom equipment in equipmentInRoom)
                    ret += equipment.Name + " - " + equipment.Quantity.ToString() + ", ";
                return ret.Substring(0, ret.Length - 2);
            } else
            {
                ret = "Nema opreme";
                return ret;
            }
            
        }
    }
}
