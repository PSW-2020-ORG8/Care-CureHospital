using Backend.Model.BlogAndNotification;
using Backend.Model.PatientDoctor;
using Backend.Repository.BlogNotificationRepository;
using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Repository.MySQL.Stream;
using Backend.Service.BlogNotificationServices;
using Backend.Service.ExaminationSurgeryServices;
using Model.Patient;
using Model.PatientDoctor;
using Repository.IDSequencer;
using Repository.MedicalRecordRepository;
using Service.MedicalRecordService;
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
        public MedicalExaminationReportService medicalExaminationReportService;
        public MedicalRecordService medicalRecordService;
        public SurveyService surveyService;

        private App()
        {
            patientFeedbackService = new PatientFeedbackService(
                new PatientFeedbackRepository(new MySQLStream<PatientFeedback>(), new IntSequencer()));
            medicalExaminationReportService = new MedicalExaminationReportService(
               new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>(), new IntSequencer()));
            medicalRecordService = new MedicalRecordService(
               new MedicalRecordRepository(new MySQLStream<MedicalRecord>(), new IntSequencer()));
            surveyService = new SurveyService(
               new SurveyRepository(new MySQLStream<Survey>(), new IntSequencer()));
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
