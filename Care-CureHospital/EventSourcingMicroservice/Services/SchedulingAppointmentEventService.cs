using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Domain.SchedulingAppointmentEvents;
using EventSourcingMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Services
{
    public class SchedulingAppointmentEventService : ISchedulingAppointmentEventService
    {
        private readonly IRepository _repository;
        public SchedulingAppointmentEventService(IRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<DomainEvent> Load(EventType eventType)
        {
            return _repository.Load(eventType);
        }
        public DomainEvent Save(DomainEvent domainEvent)
        {
            return _repository.Save(domainEvent);
        }

        public double GetSuccessfulSchedulingPercentage()
        {
            IEnumerable<EndSchedulingAppointmentEvent> endSchedulingAppointmenEvents = (IEnumerable<EndSchedulingAppointmentEvent>) Load(EventType.END_SCHEDULING_APPOINTMENT_EVENT);
            double sum = 0;
            foreach (EndSchedulingAppointmentEvent e in endSchedulingAppointmenEvents)
            {
                if (e.SchedulingResultType == SchedulingResultType.SUCCESSFUL)
                {
                    sum++;
                }
            }
            return sum / (double) endSchedulingAppointmenEvents.Count();
        }

        public double GetAverageSchedulingTime(SchedulingResultType schedulingResult)
        {
            double sum = 0;
            int successfulSchedulingsCount = 0;
            foreach (StartSchedulingAppointmentEvent startEvent in Load(EventType.START_SCHEDULING_APPOINTMENT_EVENT))
            {
                EndSchedulingAppointmentEvent endEvent = GetEndSchedulingAppointmentEventForStartAppointmentEvent(startEvent);
                if (endEvent.SchedulingResultType == schedulingResult)
                {
                    sum += (endEvent.TimeStamp - startEvent.TimeStamp).TotalSeconds;
                    successfulSchedulingsCount++;
                }
            }
            return sum / (double) successfulSchedulingsCount;
        }

        public Dictionary<int, double> GetAverageTimeSpentPerStep()
        {
            Dictionary<int, List<double>> pairs = new Dictionary<int, List<double>>();
            foreach (StartSchedulingAppointmentEvent startEvent in Load(EventType.START_SCHEDULING_APPOINTMENT_EVENT))
            {
                EndSchedulingAppointmentEvent endEvent = GetEndSchedulingAppointmentEventForStartAppointmentEvent(startEvent);
                Dictionary<int, double> currentPairs = GetAverageTimeSpentPerStepForSingleScheduling(startEvent, endEvent);
                InsertOneDictionaryToAnother(pairs, currentPairs);
            }
            return CalculateAverageDictionaryValues(pairs); 
        }

        public void InsertOneDictionaryToAnother(Dictionary<int, List<double>> first, Dictionary<int, double> second)
        {
            foreach (int key in second.Keys)
            {
                if (!first.ContainsKey(key))
                {
                    first.Add(key, new List<double>()); 
                }
                first[key].Add(second[key]);
            }
        }

        public Dictionary<int, double> CalculateAverageDictionaryValues(Dictionary<int, List<double>> pairs)
        {
            Dictionary<int, double> ret = new Dictionary<int, double> { { 1, 0.0 }, { 2, 0.0 }, { 3, 0.0 }, { 4, 0.0 } };
            foreach (int key in pairs.Keys)
            {
                ret[key] = pairs[key].Sum() / (double) pairs[key].Count();
            }
            return ret;
        }

        public Dictionary<int, double> GetAverageTimeSpentPerStepForSingleScheduling(StartSchedulingAppointmentEvent startEvent, EndSchedulingAppointmentEvent endEvent)
        {
            Dictionary<int, double> pairs = new Dictionary<int, double>();
            IEnumerable<SchedulingAppointmentStepEvent> steps = GetStepEventsForSingleScheduling(startEvent, endEvent);
            for (int i = 1; i < 5; i++)
            {
                IEnumerable<SchedulingAppointmentStepEvent> currentSteps = steps.Where(s => s.StepNumber == i);
                foreach (SchedulingAppointmentStepEvent s in currentSteps)
                {
                    pairs.Add(i, GetAverageTimeSpentPerSingleStep(i, steps, endEvent));
                }    
            }
            return pairs;
        }

        public double GetAverageTimeSpentPerSingleStep(int stepNumber, IEnumerable<SchedulingAppointmentStepEvent> steps, EndSchedulingAppointmentEvent endStep)
        {
            double sum = 0;
            IEnumerable<SchedulingAppointmentStepEvent> currentSteps = steps.Where(s => s.StepNumber == stepNumber);
            foreach (SchedulingAppointmentStepEvent step in currentSteps)
            {
                if (steps.OrderBy(s => s.TimeStamp).Last().TimeStamp > step.TimeStamp)
                {
                    sum += (steps.Where(s => s.TimeStamp > step.TimeStamp).OrderBy(s => s.TimeStamp).FirstOrDefault().TimeStamp - step.TimeStamp).TotalSeconds;
                }
                else
                {
                    sum += (endStep.TimeStamp - step.TimeStamp).TotalSeconds;
                }
            }
            return sum / (double) currentSteps.Count();
        }

        public EndSchedulingAppointmentEvent GetEndSchedulingAppointmentEventForStartAppointmentEvent(StartSchedulingAppointmentEvent startEvent)
        {
            IEnumerable<EndSchedulingAppointmentEvent> endSchedulingAppointmenEvents = (IEnumerable<EndSchedulingAppointmentEvent>)Load(EventType.END_SCHEDULING_APPOINTMENT_EVENT);
            return endSchedulingAppointmenEvents.Where(e => e.PatientUsername.Equals(startEvent.PatientUsername) && e.TimeStamp > startEvent.TimeStamp)
                                                                .OrderBy(e => e.TimeStamp).FirstOrDefault();
        }

        public int GetMostOftenQuitingStep()
        {
            List<int> quitingSteps = GetQuitStepForAllSchedulings();
            return FindMostOccuringValue(quitingSteps);
        }

        public List<int> GetQuitStepForAllSchedulings()
        {
            List<int> ret = new List<int>();
            foreach (StartSchedulingAppointmentEvent startEvent in Load(EventType.START_SCHEDULING_APPOINTMENT_EVENT))
            {
                EndSchedulingAppointmentEvent endEvent = GetEndSchedulingAppointmentEventForStartAppointmentEvent(startEvent);
                if (endEvent.SchedulingResultType == SchedulingResultType.UNSUCCESSFUL)
                {
                    ret.Add(GetQuitingStepForSingleScheduling(startEvent, endEvent));
                }
            }
            return ret;
        }

        public int GetQuitingStepForSingleScheduling(StartSchedulingAppointmentEvent startEvent, EndSchedulingAppointmentEvent endEvent)
        {
            IEnumerable<SchedulingAppointmentStepEvent> steps = GetStepEventsForSingleScheduling(startEvent, endEvent);
            return steps.Any() ? steps.OrderBy(s => s.TimeStamp).Last().StepNumber : 1;
        }

        public IEnumerable<SchedulingAppointmentStepEvent> GetStepEventsForSingleScheduling(StartSchedulingAppointmentEvent startEvent, EndSchedulingAppointmentEvent endEvent)
        {
            IEnumerable<SchedulingAppointmentStepEvent> stepSchedulingAppointmenEvents = (IEnumerable<SchedulingAppointmentStepEvent>)Load(EventType.SCHEDULING_APPOINTMENT_STEP_EVENT);
            return stepSchedulingAppointmenEvents.Where(step => step.PatientUsername.Equals(startEvent.PatientUsername) && step.TimeStamp < endEvent.TimeStamp
                && step.TimeStamp > startEvent.TimeStamp);
        }

        public int FindMostOccuringValue(List<int> values)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            foreach (int value in values)
            {
                if (pairs.ContainsKey(value))
                {
                    pairs[value]++;
                }
                else
                {
                    pairs.Add(value, 1);
                }
            }
            return pairs.Any() ? pairs.Keys.FirstOrDefault(k => pairs[k] == pairs.Values.Max()) : 0;
        }
    }
}
