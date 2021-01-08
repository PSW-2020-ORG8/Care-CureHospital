using System;
using AppointmentMicroservice.DataBase;
using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Repository;
using AppointmentMicroservice.Repository.MySQL.Stream;
using AppointmentMicroservice.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace AppointmentMicroservice
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

            services.AddSingleton<IAppointmentService, AppointmentService>(service => 
                    new AppointmentService(new AppointmentRepository(new MySQLStream<Appointment>())));
            services.AddSingleton<IDoctorWorkDayService, DoctorWorkDayService>(service => 
                    new DoctorWorkDayService(new DoctorWorkDayRepository(new MySQLStream<DoctorWorkDay>())));
            services.AddSingleton<IMedicalExaminationService, MedicalExaminationService>(service =>
                    new MedicalExaminationService(new MedicalExaminationRepository(new MySQLStream<MedicalExamination>())));
            
            services.AddControllers();
            services.AddDbContext<AppointmentDataBaseContext>(options =>
                  options.UseMySql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies(), ServiceLifetime.Transient);
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
