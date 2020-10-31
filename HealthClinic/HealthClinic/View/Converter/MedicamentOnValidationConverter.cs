using HealthClinic.View.ViewModel;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class MedicamentOnValidationConverter : AbstractConverter
    {
        public static ViewMedicamentOnValidation ConvertMedicamentToMedicamentView(ValidationOfMedicament medicamentOnValidation)
        {
            return new ViewMedicamentOnValidation
            {
                Id = medicamentOnValidation.GetId(),
                Code = medicamentOnValidation.Medicament.Code,
                Name = medicamentOnValidation.Medicament.Name,
                Doctor = medicamentOnValidation.Doctor.Name + " " + medicamentOnValidation.Doctor.Surname,
                State = StateOfMedicament(medicamentOnValidation.Medicament.StateOfValidation.ToString())
            };
        }

        public static IList<ViewMedicamentOnValidation> ConvertMedicamentListToMedicamentViewList(IList<ValidationOfMedicament> medicaments)
            => ConvertEntityListToViewList(medicaments, ConvertMedicamentToMedicamentView);

        private static String StateOfMedicament(String state)
        {
            String ret = "";
            if (state.Equals("Confirmed"))
                ret = "Validan";
            else if (state.Equals("Rejected"))
                ret = "Odbijen";
            else if (state.Equals("OnValidation"))
                ret = "Čeka na validaciju";
            return ret;
        }
    }
}
