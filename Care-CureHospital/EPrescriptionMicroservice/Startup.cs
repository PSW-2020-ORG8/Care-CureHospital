using EPrescriptionMicroservice.DataBase;
using EPrescriptionMicroservice.Domain;
using EPrescriptionMicroservice.Repository;
using EPrescriptionMicroservice.Repository.MySQL.Stream;
using EPrescriptionMicroservice.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EPrescriptionMicroservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddSingleton<IEPrescriptionService, EPrescriptionService>(report => new EPrescriptionService(new EPrescriptionRepository(new MySQLStream<EPrescription>())));
            services.AddSingleton<ISftpService, SftpService>(sftp => new SftpService());
            services.AddDbContext<EPrescriptionDataBaseContext>(options =>
                   options.UseMySql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies(), ServiceLifetime.Transient);

            services.AddControllers();
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
