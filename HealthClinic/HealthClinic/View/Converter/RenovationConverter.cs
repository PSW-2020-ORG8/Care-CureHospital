using HealthClinic.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class RenovationConverter : AbstractConverter
    { 

        public static ViewRenovation ConvertRenovationToRenovationView(Model.Term.Renovation renovation)
        {
            return new ViewRenovation
            {
                Id = renovation.GetId(),
                Room = renovation.Room.RoomID,
                DatePeriod = renovation.FromDateTime.ToString("dd.MM.yyyy.") + " - " + renovation.ToDateTime.ToString("dd.MM.yyyy."),
                Description = renovation.DescriptionOfRenovation
            };
        }

        public static IList<ViewRenovation> ConvertRenovationListToRenovationViewList(IList<Model.Term.Renovation> renovations)
            => ConvertEntityListToViewList(renovations, ConvertRenovationToRenovationView);
    }
}
