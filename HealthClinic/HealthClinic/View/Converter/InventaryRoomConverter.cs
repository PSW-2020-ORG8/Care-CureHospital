using HealthClinic.View.ViewModel;
using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class InventaryRoomConverter : AbstractConverter
    {

        public static ViewInventaryRoom ConvertInventaryRoomToInventaryRoomView(InventaryRoom equipment)
        {
            return new ViewInventaryRoom
            {
                Id = equipment.GetId(),
                Name = equipment.Name,
                Quantity = equipment.Quantity
            };
        }

        public static IList<ViewInventaryRoom> ConvertInventaryRoomListToInventaryRoomViewList(IList<InventaryRoom> equipments)
            => ConvertEntityListToViewList(equipments, ConvertInventaryRoomToInventaryRoomView);
    }
}
