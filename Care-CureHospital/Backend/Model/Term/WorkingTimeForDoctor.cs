/***********************************************************************
 * Module:  WorkingTimeForDoctor.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Manager.WorkingTimeForDoctor
 ***********************************************************************/

using HealthClinic.Repository;
using Model.Manager;
using System;

namespace Model.Term
{
    public class WorkingTimeForDoctor : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public DaysInWeek Day { get; set; }
        public Boolean DoesWork { get; set; }
        public int DoctorId { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }

        public WorkingTimeForDoctor(int id)
        {
            this.Id = id;
        }

        public WorkingTimeForDoctor()
        {
        }

        public WorkingTimeForDoctor(int id, DaysInWeek day, bool doesWork, AllActors.Doctor doctor, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Day = day;
            this.DoesWork = doesWork;
            this.Id = id;
            this.Doctor = doctor;
        }

        public WorkingTimeForDoctor(DaysInWeek day, bool doesWork, AllActors.Doctor doctor, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Day = day;
            this.DoesWork = doesWork;
            this.Doctor = doctor;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}