using Controller.BlogNotificationControlers;
using Controller.ExaminationSurgeryControlers;
using Controller.MedicalRecordControlers;
using Controller.MedicamentControlers;
using Controller.RoomsControlers;
using Controller.UsersControlers;
using Model.Manager;
using Repository.CSV.Converter;
using Repository.RoomsRepository;
using Service.RoomsServices;
using Model.AllActors;
using Model.BlogAndNotification;
using Model.Doctor;
using Model.DoctorMenager;
using Model.Patient;
using Model.PatientDoctor;
using Model.Term;
using Repository.BlogNotificationRepository;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.ExaminationSurgeryRepository;
using Repository.IDSequencer;
using Repository.MedicalRecordRepository;
using Repository.MedicamentRepository;
using Repository.UsersRepository;
using Service.BlogNotificationServices;
using Service.ExaminationSurgeryServices;
using Service.MedicalRecordService;
using Service.MedicamentService;
using Service.UsersServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HealthClinic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ARTICLE_FILE = "../../Resources/Data/articles.csv";
        private const string NOTIFICATION_FILE = "../../Resources/Data/notifications.csv";
        private const string SURVEY_FILE = "../../Resources/Data/surveys.csv";
        private const string HOSPITALITATION_FILE = "../../Resources/Data/hospitalitations.csv";
        private const string MEDICALEXAMINATION_FILE = "../../Resources/Data/medicalexaminations.csv";
        private const string SURGERY_FILE = "../../Resources/Data/surgeries.csv";
        private const string ALLERGIES_FILE = "../../Resources/Data/allergies.csv";
        private const string DIAGNOSIS_FILE = "../../Resources/Data/diagnosis.csv";
        private const string MEDICALRECORD_FILE = "../../Resources/Data/medicalrecords.csv";
        private const string SYMPTOMS_FILE = "../../Resources/Data/symptoms.csv";
        private const string ISSUEOFMEDICAMENTS_FILE = "../../Resources/Data/issueofmedicaments.csv";
        private const string MEDICAMNET_FILE = "../../Resources/Data/medicaments.csv";
        private const string VALIDATIONOFMEDICAMENT_FILE = "../../Resources/Data/validationofmedicament.csv";
        private const string EQUIPMENT_FILE = "../../Resources/Data/equipment.csv";
        private const string RENOVATION_FILE = "../../Resources/Data/renovation.csv";
        private const string ROOM_FILE = "../../Resources/Data/room.csv";
        private const string SPECIALITATION_FILE = "../../Resources/Data/specialitation.csv";
        private const string USER_FILE = "../../Resources/Data/users.csv";
        private const string WORKINGTIMEFORDOCTOR_FILE = "../../Resources/Data/workingtimefordoctor.csv";
        private const string INVENTARY_FILE = "../../Resources/Data/inventaryRoom.csv";

        private const string CSV_DELIMITER = ",";

        private const string DATETIME_FORMAT = "dd.MM.yyyy.";

        public App()
        {
          
            var articleRepository = new ArticleRepository(
                new CSVStream<Article>(ARTICLE_FILE, new ArticleCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var notificationRepository = new NotificationRepository(
                new CSVStream<Notification>(NOTIFICATION_FILE, new NotificationCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var surveyRepository = new SurveyRepository(
                new CSVStream<Survey>(SURVEY_FILE, new SurveyCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var hospitalitationRepository = new HospitalitationRepository(
                new CSVStream<Hospitalitation>(HOSPITALITATION_FILE, new HospitalitationCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var medicalExaminationRepository = new MedicalExaminationRepository(
                new CSVStream<MedicalExamination>(MEDICALEXAMINATION_FILE, new MedicalExaminationCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var surgeryRepository = new SurgeryRepository(
                new CSVStream<Surgery>(SURGERY_FILE, new SurgeryCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var allergiesRepository = new AllergiesRepository(
                new CSVStream<Allergies>(ALLERGIES_FILE, new AlergiesCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var diagnosisRepository = new DiagnosisRepository(
                new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var medicalRecordRepository = new MedicalRecordRepository(
               new CSVStream<MedicalRecord>(MEDICALRECORD_FILE, new MedicalRecordCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var symptomsRepository = new SymptomsRepository(
               new CSVStream<Symptoms>(SYMPTOMS_FILE, new SymptomsCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var issueOfMedicamentsRepository = new IssueOfMedicamentRepository(
              new CSVStream<IssueOfMedicaments>(ISSUEOFMEDICAMENTS_FILE, new IssueMedicamentCSVConverter(CSV_DELIMITER)),
              new IntSequencer());
            var medicamentRepository = new MedicamentRepository(
                new CSVStream<Medicament>(MEDICAMNET_FILE, new MedicamentCSVConverter(CSV_DELIMITER)),
                new IntSequencer());
            var validationOfMedicamentRepository = new ValidationOfMedicamentRepository(
               new CSVStream<ValidationOfMedicament>(VALIDATIONOFMEDICAMENT_FILE, new ValidationMedicamentCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var equipmentRepository = new EquipmentRepository(
               new CSVStream<Equipment>(EQUIPMENT_FILE, new EquipmentCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var renovationRepository = new RenovationRepository(
               new CSVStream<Renovation>(RENOVATION_FILE, new RenovationCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var roomRepository = new RoomRepository(
               new CSVStream<Room>(ROOM_FILE, new RoomCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var userRepository = new UserRepository(
               new CSVStream<User>(USER_FILE, new UserCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var workingTimeForDoctorRepository = new WorkingTimeForDoctorRepository(
               new CSVStream<WorkingTimeForDoctor>(WORKINGTIMEFORDOCTOR_FILE, new WorkingTimeForDoctorCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var specialitationRepository = new SpecialitationRepository(
               new CSVStream<Specialitation>(SPECIALITATION_FILE, new SpecialitationCSVConverter(CSV_DELIMITER)),
               new IntSequencer());
            var inventaryRoomRepository = new InventaryRoomRepository(
                new CSVStream<InventaryRoom>(INVENTARY_FILE, new InventaryRoomCSVConverter(CSV_DELIMITER)),
                new IntSequencer());


            var articleService = new ArticleService(articleRepository);
            var notificationService = new NotificationService(notificationRepository);
            var surveyService = new SurveyService(surveyRepository);
            var hospitalitationService = new HospitalitationService(hospitalitationRepository);
            var medicalExaminationService = new MedicalExaminationService(medicalExaminationRepository);
            var surgeryService = new SurgeryService(surgeryRepository);
            var allergiesService = new AllergiesService(allergiesRepository);
            var diagnosisService = new DiagnosisService(diagnosisRepository);
            var medicalRecordService = new MedicalRecordService(medicalRecordRepository);
            var symptomsService = new SymptomsService(symptomsRepository);
            var issueOfMedicamentsService = new IssueMedicamentsService(issueOfMedicamentsRepository);
            var medicamentService = new MedicamentService(medicamentRepository);
            var validationOfMedicamentService = new ValidationMedicamentService(validationOfMedicamentRepository);
            var equipmentService = new EquipmentService(equipmentRepository);
            var roomService = new RoomService(roomRepository);
            var renovationService = new RenovationService(renovationRepository, roomService);
            var userService = new UserService(userRepository);
            var workingTimeForDoctorService = new WorkingTimeForDoctorService(workingTimeForDoctorRepository);
            var spetialitationService = new SpetialitationService(specialitationRepository);
            var inventaryRoomService = new InventaryRoomService(inventaryRoomRepository);

            ArticleController = new ArticleController(articleService);
            NotificationController = new NotificationController(notificationService);
            SurveyController = new SurveyController(surveyService);
            HospitalitationController = new HospitalitationController(hospitalitationService);
            MedicalExaminationController = new MedicalExaminationController(medicalExaminationService);
            SurgeryController = new SurgeryController(surgeryService);
            AllergiesController = new AllergiesController(allergiesService);
            DiagnosisController = new DiagnosisController(diagnosisService);
            MedicalRecordController = new MedicalRecordController(medicalRecordService);
            SymptomsController = new SymptomsController(symptomsService);
            IssueOfMedicamentsController = new IssueMedicamentsController(issueOfMedicamentsService);
            MedicamentController = new MedicamentController(medicamentService);
            ValidationOfMedicamentController = new ValidationMedicamentController(validationOfMedicamentService);
            EquipmentController = new EquipmentController(equipmentService);
            RenovationController = new RenovationController(renovationService);
            RoomController = new RoomController(roomService);
            UserController = new UserController(userService);
            WorkingTimeForDoctorController = new WorkingTimeForDoctorController(workingTimeForDoctorService);
            SpetialitationController = new SpetialitationController(spetialitationService);
            InventaryRoomController = new InventaryRoomController(inventaryRoomService);

        }

        public ArticleController ArticleController { get; private set; }
        public NotificationController NotificationController { get; private set; }
        public SurveyController SurveyController { get; private set; }
        public HospitalitationController HospitalitationController { get; private set; }
        public MedicalExaminationController MedicalExaminationController { get; private set; }
        public SurgeryController SurgeryController { get; private set; }
        public AllergiesController AllergiesController { get; private set; }
        public DiagnosisController DiagnosisController { get; private set; }
        public MedicalRecordController MedicalRecordController { get; private set; }
        public SymptomsController SymptomsController { get; private set; }
        public IssueMedicamentsController IssueOfMedicamentsController { get; private set; }
        public MedicamentController MedicamentController { get; private set; }
        public ValidationMedicamentController ValidationOfMedicamentController { get; private set; }
        public EquipmentController EquipmentController { get; private set; }
        public RenovationController RenovationController { get; private set; }
        public RoomController RoomController { get; private set; }
        public UserController UserController { get; private set; }
        public WorkingTimeForDoctorController WorkingTimeForDoctorController { get; private set; }
        public SpetialitationController SpetialitationController { get; private set; }
        public InventaryRoomController InventaryRoomController { get; private set; }

    }
}