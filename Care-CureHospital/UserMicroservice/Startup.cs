using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UserMicroservice.DataBase;
using UserMicroservice.Domain;
using UserMicroservice.Repository;
using UserMicroservice.Repository.MySQL.Stream;
using UserMicroservice.Service;

namespace UserMicroservice
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
            services.AddSingleton<IDoctorService, DoctorService>(service =>
                    new DoctorService(new DoctorRepository(new MySQLStream<Doctor>())));
            services.AddSingleton<IPatientService, PatientService>(service =>
                    new PatientService(new PatientRepository(new MySQLStream<Patient>())));
            services.AddSingleton<ISpecializationService, SpecializationService>(service =>
                    new SpecializationService(new SpecializationRepository(new MySQLStream<Specialitation>())));
            services.AddSingleton<ISystemAdministratorService, SystemAdministratorService>(service =>
                    new SystemAdministratorService(new SystemAdministratorRepository(new MySQLStream<SystemAdministrator>())));
            services.AddSingleton<IUserService, UserService>(service =>
                    new UserService(new UserRepository(new MySQLStream<User>()),
                        new PatientService(new PatientRepository(new MySQLStream<Patient>())),
                            new SystemAdministratorService(new SystemAdministratorRepository(new MySQLStream<SystemAdministrator>()))));
            services.AddDbContext<UserDataBaseContext>(options =>
                   options.UseMySql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies(), ServiceLifetime.Transient);

            services.AddControllers();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
