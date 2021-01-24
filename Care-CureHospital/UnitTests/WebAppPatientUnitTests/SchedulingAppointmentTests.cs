using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Domain.SchedulingAppointmentEvents;
using EventSourcingMicroservice.Repository;
using EventSourcingMicroservice.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.WebAppPatientUnitTests
{
    public class SchedulingAppointmentTests
    {
        [Fact]
        public void Get_successful_scheduling_percentage()
        {
            SchedulingAppointmentEventService schedulingAppointmentEventService = new SchedulingAppointmentEventService(CreateSchedulingAppointmentStubRepository());

            double result = schedulingAppointmentEventService.GetSuccessfulSchedulingPercentage();

            Assert.Equal(0.5, result);
        }

        [Fact]
        public void Get_average_successful_scheduling_time()
        {
            SchedulingAppointmentEventService schedulingAppointmentEventService = new SchedulingAppointmentEventService(CreateSchedulingAppointmentStubRepository());

            double result = schedulingAppointmentEventService.GetAverageSchedulingTime(SchedulingResultType.SUCCESSFUL);

            Assert.Equal(55, result);
        }

        [Fact]
        public void Get_average_scheduling_time_unsuccessful()
        {
            SchedulingAppointmentEventService schedulingAppointmentEventService = new SchedulingAppointmentEventService(CreateSchedulingAppointmentStubRepository());

            double result = schedulingAppointmentEventService.GetAverageSchedulingTime(SchedulingResultType.UNSUCCESSFUL);

            Assert.Equal(80, result);
        }

        [Fact]
        public void Get_average_time_spent_per_third_step()
        {
            SchedulingAppointmentEventService schedulingAppointmentEventService = new SchedulingAppointmentEventService(CreateSchedulingAppointmentStubRepository());

            Dictionary<int, double> result = schedulingAppointmentEventService.GetAverageTimeSpentPerStep();

            Assert.Equal(30, result[3]);
        }

        [Fact]
        public void Get_average_time_spent_per_fourth_step()
        {
            SchedulingAppointmentEventService schedulingAppointmentEventService = new SchedulingAppointmentEventService(CreateSchedulingAppointmentStubRepository());

            Dictionary<int, double> result = schedulingAppointmentEventService.GetAverageTimeSpentPerStep();

            Assert.Equal(15, result[4]);
        }

        [Fact]
        public void Get_most_often_quiting_step()
        {
            SchedulingAppointmentEventService schedulingAppointmentEventService = new SchedulingAppointmentEventService(CreateSchedulingAppointmentStubRepository());

            int result = schedulingAppointmentEventService.GetMostOftenQuitingStep();

            Assert.Equal(3, result);
        }

        private static IRepository CreateSchedulingAppointmentStubRepository()
        {
            var stubRepository = new Mock<IRepository>();

            var startSchedulingAppointments = new List<StartSchedulingAppointmentEvent>();
            var endSchedulingAppointments = new List<EndSchedulingAppointmentEvent>();
            var schedulingAppointmentsStep = new List<SchedulingAppointmentStepEvent>();

            startSchedulingAppointments.Add(new StartSchedulingAppointmentEvent("pera", new DateTime(2021, 1, 15, 13, 00, 00)));
            startSchedulingAppointments.Add(new StartSchedulingAppointmentEvent("pera", new DateTime(2021, 1, 15, 14, 00, 00)));
            startSchedulingAppointments.Add(new StartSchedulingAppointmentEvent("pera", new DateTime(2021, 1, 15, 15, 00, 00)));
            startSchedulingAppointments.Add(new StartSchedulingAppointmentEvent("pera", new DateTime(2021, 1, 15, 16, 00, 00)));

            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 1, StepType.FORWARD, new DateTime(2021, 1, 15, 13, 00, 10)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 2, StepType.FORWARD, new DateTime(2021, 1, 15, 13, 00, 20)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 3, StepType.FORWARD, new DateTime(2021, 1, 15, 13, 00, 30)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 4, StepType.FORWARD, new DateTime(2021, 1, 15, 13, 00, 40)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 1, StepType.FORWARD, new DateTime(2021, 1, 15, 14, 00, 10)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 2, StepType.FORWARD, new DateTime(2021, 1, 15, 14, 00, 20)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 3, StepType.FORWARD, new DateTime(2021, 1, 15, 14, 00, 30)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 4, StepType.FORWARD, new DateTime(2021, 1, 15, 14, 00, 40)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 1, StepType.FORWARD, new DateTime(2021, 1, 15, 15, 00, 10)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 2, StepType.FORWARD, new DateTime(2021, 1, 15, 15, 00, 20)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 3, StepType.FORWARD, new DateTime(2021, 1, 15, 15, 00, 30)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 1, StepType.FORWARD, new DateTime(2021, 1, 15, 16, 00, 10)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 2, StepType.FORWARD, new DateTime(2021, 1, 15, 16, 00, 20)));
            schedulingAppointmentsStep.Add(new SchedulingAppointmentStepEvent("pera", 3, StepType.FORWARD, new DateTime(2021, 1, 15, 16, 00, 30)));

            endSchedulingAppointments.Add(new EndSchedulingAppointmentEvent("pera", SchedulingResultType.SUCCESSFUL, new DateTime(2021, 1, 15, 13, 01, 00)));
            endSchedulingAppointments.Add(new EndSchedulingAppointmentEvent("pera", SchedulingResultType.SUCCESSFUL, new DateTime(2021, 1, 15, 14, 00, 50)));
            endSchedulingAppointments.Add(new EndSchedulingAppointmentEvent("pera", SchedulingResultType.UNSUCCESSFUL, new DateTime(2021, 1, 15, 15, 01, 50)));
            endSchedulingAppointments.Add(new EndSchedulingAppointmentEvent("pera", SchedulingResultType.UNSUCCESSFUL, new DateTime(2021, 1, 15, 16, 00, 50)));

            stubRepository.Setup(repository => repository.Load(EventType.START_SCHEDULING_APPOINTMENT_EVENT)).Returns(startSchedulingAppointments);
            stubRepository.Setup(repository => repository.Load(EventType.END_SCHEDULING_APPOINTMENT_EVENT)).Returns(endSchedulingAppointments);
            stubRepository.Setup(repository => repository.Load(EventType.SCHEDULING_APPOINTMENT_STEP_EVENT)).Returns(schedulingAppointmentsStep);
            return stubRepository.Object;
        }
    }
}
