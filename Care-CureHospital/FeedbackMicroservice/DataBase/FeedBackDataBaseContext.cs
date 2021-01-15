using FeedbackMicroservice.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace FeedbackMicroservice.DataBase
{
    public class FeedBackDataBaseContext : DbContext
    {
      
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }

        public FeedBackDataBaseContext() : base() { }
        public FeedBackDataBaseContext(DbContextOptions<FeedBackDataBaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("* * * * * * * * * * * * *");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseMySql(CreateConnectionStringFromEnvironment());
            }
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "HealthClinicDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            string sslMode = Environment.GetEnvironmentVariable("DATABASE_SSL_MODE") ?? "None";
            Console.WriteLine(server);
            Console.WriteLine(port);
            Console.WriteLine(user);
            Console.WriteLine(password);
            Console.WriteLine(database);
            return $"server={server};port={port};database={database};user={user};password={password};";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<PatientFeedback>().HasData(
                new PatientFeedback { Id = 1, Text = "Sve pohvale, napokon nema cekanja.", PublishingDate = new DateTime(2020, 10, 30, 10, 30, 0), IsForPublishing = true, IsPublished = true, IsAnonymous = false, PatientId = 1 },
                new PatientFeedback { Id = 2, Text = "Usluga je vrhunska.", PublishingDate = new DateTime(2020, 8, 15, 9, 17, 0), IsForPublishing = true, IsPublished = true, IsAnonymous = true, PatientId = 2 },
                new PatientFeedback { Id = 3, Text = "Sve super.", PublishingDate = new DateTime(2020, 9, 3, 11, 30, 0), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientId = 3 },
                new PatientFeedback { Id = 4, Text = "Osoblje je vrlo ljubazno.", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientId = 4 },
                new PatientFeedback { Id = 5, Text = "Lekari su izuzetno strucni.", PublishingDate = new DateTime(2020, 10, 18, 7, 30, 0), IsForPublishing = false, IsPublished = false, IsAnonymous = false, PatientId = 2 },
                new PatientFeedback { Id = 6, Text = "Svidja mi se sto mogu u svakom trenutku da upravljam svojim terminima", PublishingDate = new DateTime(2020, 10, 15, 6, 30, 0), IsForPublishing = true, IsPublished = false, IsAnonymous = true, PatientId = 4 }
            );

            modelBuilder.Entity<Survey>().HasData(
                new Survey { Id = 1, Title = "Naslov", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), CommentSurvey = "Sve je super u bolnici", MedicalExaminationId = 1, Answers = new List<Answer>() },
                new Survey { Id = 2, Title = "Naslov", PublishingDate = new DateTime(2020, 11, 6, 8, 30, 0), CommentSurvey = "Sve je super u bolnici", MedicalExaminationId = 2, Answers = new List<Answer>() }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuestionText = "Ljubaznost doktora prema pacijentu", QuestionType = QuestionType.Doctor },
                new Question { Id = 2, QuestionText = "Posvećenost doktora pacijentu", QuestionType = QuestionType.Doctor },
                new Question { Id = 3, QuestionText = "Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja", QuestionType = QuestionType.Doctor },
                new Question { Id = 4, QuestionText = "Ljubaznost medicinskog osoblja prema pacijentu", QuestionType = QuestionType.Staff },
                new Question { Id = 5, QuestionText = "Posvećenost medicinskog osoblja pacijentu", QuestionType = QuestionType.Staff },
                new Question { Id = 6, QuestionText = "Profesionalizam u obavljanju svoji duznosti medicinskog osoblja", QuestionType = QuestionType.Staff },
                new Question { Id = 7, QuestionText = "Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici", QuestionType = QuestionType.Hospital },
                new Question { Id = 8, QuestionText = "Higijena unutar bolnice", QuestionType = QuestionType.Hospital },
                new Question { Id = 9, QuestionText = "Opremljenost bolnice", QuestionType = QuestionType.Hospital }
            );

            modelBuilder.Entity<Answer>().HasData(
               new Answer { Id = 1, Grade = GradeOfQuestion.Fair, QuestionId = 1, SurveyId = 1 },
               new Answer { Id = 2, Grade = GradeOfQuestion.Excellent, QuestionId = 2, SurveyId = 1 },
               new Answer { Id = 3, Grade = GradeOfQuestion.Good, QuestionId = 3, SurveyId = 1 },
               new Answer { Id = 4, Grade = GradeOfQuestion.VeryGood, QuestionId = 4, SurveyId = 1 },
               new Answer { Id = 5, Grade = GradeOfQuestion.Poor, QuestionId = 5, SurveyId = 1 },
               new Answer { Id = 6, Grade = GradeOfQuestion.Excellent, QuestionId = 6, SurveyId = 1 },
               new Answer { Id = 7, Grade = GradeOfQuestion.Fair, QuestionId = 7, SurveyId = 1 },
               new Answer { Id = 8, Grade = GradeOfQuestion.Fair, QuestionId = 8, SurveyId = 1 },
               new Answer { Id = 9, Grade = GradeOfQuestion.VeryGood, QuestionId = 9, SurveyId = 2 },
               new Answer { Id = 10, Grade = GradeOfQuestion.Good, QuestionId = 1, SurveyId = 2 },
               new Answer { Id = 11, Grade = GradeOfQuestion.Excellent, QuestionId = 2, SurveyId = 2 },
               new Answer { Id = 12, Grade = GradeOfQuestion.Excellent, QuestionId = 3, SurveyId = 2 },
               new Answer { Id = 13, Grade = GradeOfQuestion.VeryGood, QuestionId = 4, SurveyId = 2 },
               new Answer { Id = 14, Grade = GradeOfQuestion.Fair, QuestionId = 5, SurveyId = 2 },
               new Answer { Id = 15, Grade = GradeOfQuestion.Good, QuestionId = 6, SurveyId = 2 },
               new Answer { Id = 16, Grade = GradeOfQuestion.Good, QuestionId = 7, SurveyId = 2 },
               new Answer { Id = 17, Grade = GradeOfQuestion.Excellent, QuestionId = 8, SurveyId = 2 },
               new Answer { Id = 18, Grade = GradeOfQuestion.VeryGood, QuestionId = 9, SurveyId = 2 }
           );

            modelBuilder.Entity<Advertisement>().HasData(
                new Advertisement { Id = 1, PharmacyName = "Janković", Percent = 10, Period = "01.01.2021. - 02.02.2021.", Manufacturer = "Sandoz lekovi" },
                new Advertisement { Id = 2, PharmacyName = "Sarić", Percent = 15, Period = "05.01.2021. - 12.03.2021.", Manufacturer = "Galenika lekovi" },
                new Advertisement { Id = 3, PharmacyName = "Zegin", Percent = 25, Period = "08.01.2021. - 22.04.2021.", Manufacturer = "Pfizer lekovi" }
            );
        }
    }
}
