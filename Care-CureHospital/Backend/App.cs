using Backend.Model.BlogAndNotification;
using Backend.Repository.BlogNotificationRepository;
using Backend.Repository.MySQL.Stream;
using Backend.Service.BlogNotificationServices;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class App
    {
        private static App instance = null;

        public PatientFeedbackService patientFeedbackService;
        private App()
        {
            patientFeedbackService = new PatientFeedbackService(
                new PatientFeedbackRepository(new MySQLStream<PatientFeedback>(), new IntSequencer()));
        }

        public static App Instance()
        {
            if (instance == null)
            {
                instance = new App();
            }
            return instance;

        }
        
    }
}
