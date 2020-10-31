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
        private int id;
        private DaysInWeek day;
        private Boolean doesWork;
        private AllActors.Doctor doctor;

        public DaysInWeek Day { get => day; set => day = value; }
        public bool DoesWork { get => doesWork; set => doesWork = value; }
        public AllActors.Doctor Doctor { get => doctor; set => doctor = value; }

        public WorkingTimeForDoctor(int id)
        {
            this.id = id;
        }

        public WorkingTimeForDoctor()
        {
        }

        public WorkingTimeForDoctor(int id, DaysInWeek day, bool doesWork, AllActors.Doctor doctor, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Day = day;
            this.DoesWork = doesWork;
            this.id = id;
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
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
    }
}