using EventSourcingMicroservice.DataBase;
using EventSourcingMicroservice.Repository.MySQL;
using EventSourcingMicroservice.Services;
using FeedbackMicroservice.DataBase;
using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Gateway;
using FeedbackMicroservice.Gateway.Interface;
using FeedbackMicroservice.Repository;
using FeedbackMicroservice.Repository.MySQL.Stream;
using FeedbackMicroservice.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FeedbackMicroservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddSingleton<IPatientFeedbackService, PatientFeedbackService>(patientFeedback => new PatientFeedbackService(new PatientFeedbackRepository(new MySQLStream<PatientFeedback>())));
            services.AddSingleton<ISurveyService, SurveyService>(survey => new SurveyService(new SurveyRepository(new MySQLStream<Survey>()), new MedicalExaminationGateway(),
                new AnswerService(new AnswerRepository(new MySQLStream<Answer>()), new QuestionService(new QuestionRepository(new MySQLStream<Question>()))))); 
            services.AddSingleton<IAnswerService, AnswerService>(answer => new AnswerService(new AnswerRepository(new MySQLStream<Answer>()), new QuestionService(new QuestionRepository(new MySQLStream<Question>()))));
            services.AddSingleton<IAdvertisementService, AdvertisementService>(answer => new AdvertisementService(new AdvertisementRepository(new MySQLStream<Advertisement>())));
            services.AddSingleton<IDoctorGateway, DoctorGateway>();
            services.AddSingleton<IAppointmentGateway, AppointmentGateway>();
            services.AddSingleton<IPatientGateway, PatientGateway>();

            services.AddDbContext<FeedBackDataBaseContext>(options =>
                   options.UseMySql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies(), ServiceLifetime.Transient);

            services.AddDbContext<ESDataBaseContext>(option =>
                option.UseMySql(CreateConnectionStringFromEnvironmentEventStore()).UseLazyLoadingProxies(), ServiceLifetime.Transient);
            services.AddSingleton<IDomainEventService, DomainEventService>(services => new DomainEventService(new MySQLRepository(new ESDataBaseContext())));


            services.AddControllers();
            services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

        private string CreateConnectionStringFromEnvironmentEventStore()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA_EVENT") ?? "EventSourcingDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            string sslMode = Environment.GetEnvironmentVariable("DATABASE_SSL_MODE") ?? "None";
            return $"server={server};port={port};database={database};user={user};password={password};";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
