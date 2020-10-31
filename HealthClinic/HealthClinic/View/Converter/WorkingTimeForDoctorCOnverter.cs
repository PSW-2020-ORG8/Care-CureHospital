using HealthClinic.View.ViewModel;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class WorkingTimeForDoctorConverter : AbstractConverter
    {

        public static ViewWorkingTimeForDoctor ConvertWorkingTimeForDoctorToWorkingTimeForDoctorView(WorkingTimeForDoctor workingTimeForDoctor)
        {
            return new ViewWorkingTimeForDoctor 
            {
                Id = workingTimeForDoctor.GetId(),
                Doctor = workingTimeForDoctor.Doctor.Name + " " + workingTimeForDoctor.Doctor.Surname,
                Day = DayOfWork(workingTimeForDoctor.Day.ToString()),
                WorkingTime = GetWorkingTime(workingTimeForDoctor.DoesWork, workingTimeForDoctor.FromDateTime, workingTimeForDoctor.ToDateTime) 
            };
        }

        public static IList<ViewWorkingTimeForDoctor> ConvertWorkingTimeForDoctorListToWorkingTimeForDoctorViewList(IList<WorkingTimeForDoctor> workingTimes)
            => ConvertEntityListToViewList(workingTimes, ConvertWorkingTimeForDoctorToWorkingTimeForDoctorView);

        private static String DayOfWork(String day)
        {
            String ret = "";
            if (day.Equals("Monday"))
                ret = "Ponedeljak";
            else if (day.Equals("Tuesday"))
                ret = "Utorak";
            else if (day.Equals("Wednesday"))
                ret = "Sreda";
            else if (day.Equals("Thursday"))
                ret = "Četvrtak";
            else if (day.Equals("Friday"))
                ret = "Petak";
            else if (day.Equals("Saturday"))
                ret = "Subota";
            else if (day.Equals("Sunday"))
                ret = "Nedelja";
            return ret;
        }

        private static String GetWorkingTime(bool doesWork, DateTime start, DateTime end)
        {
            String workingTime = "";
            if (!doesWork)
                workingTime = "Ne radi";
            else
                workingTime = start.ToString("HH:mm") + " - " + end.ToString("HH:mm");
            return workingTime;
        }
    }
}
