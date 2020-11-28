using Backend.Model.BlogAndNotification;
using Backend.Model.DoctorMenager;
using Backend.Model.PatientDoctor;
using Backend.Repository.BlogNotificationRepository;
using Backend.Repository.DirectorRepository;
using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Repository.MySQL.Stream;
using Backend.Repository.UsersRepository;
using Backend.Service.BlogNotificationServices;
using Backend.Service.DirectorService;
using Backend.Service.ExaminationSurgeryServices;
using Backend.Service.UsersServices;
using Model.AllActors;
using Model.DoctorMenager;
using Model.Patient;
using Model.PatientDoctor;
using Repository.IDSequencer;
using Repository.MedicalRecordRepository;
using Repository.UsersRepository;
using Service.MedicalRecordService;
using Service.UsersServices;
using Repository.MedicamentRepository;
using Service.MedicamentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class App
    {
        private static App _instance = null;

        public SurveyService SurveyService;
        public QuestionService QuestionService;
        public PatientFeedbackService PatientFeedbackService;
        public MedicalExaminationReportService MedicalExaminationReportService;
        public PrescriptionService PrescriptionService;
        public MedicalRecordService MedicalRecordService;
        public AllergiesService AllergiesService;
        public PatientService PatientService;
        public ReportService ReportService;
        public EmailVerificationService EmailVerificationService;

        private App()
        {
            EmailVerificationService = new EmailVerificationService();
            PatientFeedbackService = new PatientFeedbackService(
                new PatientFeedbackRepository(new MySQLStream<PatientFeedback>(), new IntSequencer()));
            MedicalExaminationReportService = new MedicalExaminationReportService(
               new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>(), new IntSequencer()));
            PrescriptionService = new PrescriptionService(
               new PrescriptionRepository(new MySQLStream<Prescription>(), new IntSequencer()));
            MedicalRecordService = new MedicalRecordService(
               new MedicalRecordRepository(new MySQLStream<MedicalRecord>(), new IntSequencer()), EmailVerificationService);
            SurveyService = new SurveyService(
               new SurveyRepository(new MySQLStream<Survey>(), new IntSequencer()));
            QuestionService = new QuestionService(
                new QuestionRepository(new MySQLStream<Question>(), new IntSequencer()));
            AllergiesService = new AllergiesService(
               new AllergiesRepository(new MySQLStream<Allergies>(), new IntSequencer()));
            PatientService = new PatientService(
               new PatientRepository(new MySQLStream<Patient>(), new IntSequencer()));
            ReportService = new ReportService(
               new ReportRepository(new MySQLStream<Report>(), new IntSequencer()));           
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
