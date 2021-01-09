using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Gateway;
using DocumentsMicroservice.Gateway.Interface;
using DocumentsMicroservice.Repository;
using DocumentsMicroservice.Repository.MySQL.Stream;
using DocumentsMicroservice.Service;
using EventSourcingMicroservice.DataBase;
using EventSourcingMicroservice.Repository.MySQL;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;

namespace DocumentsMicroservice
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

            services.AddSingleton<IPatientGateway, PatientGateway>();
            services.AddSingleton<IMedicalExaminationGateway, MedicalExaminationGateway>();
            services.AddSingleton<IAllergiesService, AllergiesService>(service => new AllergiesService(new AllergiesRepository(new MySQLStream<Allergies>())));
            services.AddSingleton<IEmailVerificationService, EmailVerificationService>(service => new EmailVerificationService());
            services.AddSingleton<IMedicalExaminationReportService, MedicalExaminationReportService>(service => new MedicalExaminationReportService(new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>()), new MedicalExaminationGateway()));
            services.AddSingleton<IPrescriptionService, PrescriptionService>(service => new PrescriptionService(new PrescriptionRepository(new MySQLStream<Prescription>()), new MedicalExaminationGateway()));
            services.AddSingleton<IMedicalRecordService, MedicalRecordService>(service => new MedicalRecordService(new MedicalRecordRepository(new MySQLStream<MedicalRecord>()), new EmailVerificationService(), new PatientGateway()));

            services.AddControllers();
            services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<ESDataBaseContext>(option =>
                option.UseMySql(CreateConnectionStringFromEnvironmentEventStore()).UseLazyLoadingProxies(), ServiceLifetime.Transient);
            services.AddSingleton<IDomainEventService, DomainEventService>(services => new DomainEventService(new MySQLRepository(new ESDataBaseContext())));

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
        }
    }
}
