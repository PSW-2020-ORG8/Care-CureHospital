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
        private static App _instance = null;

        public PatientFeedbackService PatientFeedbackService;
        public MedicalExaminationReportService MedicalExaminationReportService;
        public PrescriptionService PrescriptionService;
        public MedicalRecordService MedicalRecordService;
        public SurveyService SurveyService;
        public AllergiesService AllergiesService;

        private App()
        {
            PatientFeedbackService = new PatientFeedbackService(
                new PatientFeedbackRepository(new MySQLStream<PatientFeedback>(), new IntSequencer()));
            MedicalExaminationReportService = new MedicalExaminationReportService(
               new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>(), new IntSequencer()));
            PrescriptionService = new PrescriptionService(
               new PrescriptionRepository(new MySQLStream<Prescription>(), new IntSequencer()));
            MedicalRecordService = new MedicalRecordService(
               new MedicalRecordRepository(new MySQLStream<MedicalRecord>(), new IntSequencer()));
            SurveyService = new SurveyService(
               new SurveyRepository(new MySQLStream<Survey>(), new IntSequencer()));
            AllergiesService = new AllergiesService(
               new AllergiesRepository(new MySQLStream<Allergies>(), new IntSequencer()));
        }

        public static App Instance()
        {
            if (_instance == null)
            {
                _instance = new App();
            }
            return _instance;

        }
        
    }
}
