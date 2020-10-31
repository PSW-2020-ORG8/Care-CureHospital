using HealthClinic.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class EquipmentConverter : AbstractConverter
    {

        public static ViewEquipment ConvertEquipmentToEquipmentView(Model.Manager.Equipment equipment)
        {
            return new ViewEquipment
            {
                Id = equipment.GetId(),
                Code = equipment.Code,
                Name = equipment.Name,
                TypeOfEquipment = equipment.TypeOfEquipment,
                Amount = equipment.Amount
            };
        }

        public static IList<ViewEquipment> ConvertEquipmnetListToEquipmentViewList(IList<Model.Manager.Equipment> equipments)
            => ConvertEntityListToViewList(equipments, ConvertEquipmentToEquipmentView);
    }
}
