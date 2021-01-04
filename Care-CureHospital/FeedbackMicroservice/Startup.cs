using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Repository;
using FeedbackMicroservice.Repository.MySQL.Stream;
using FeedbackMicroservice.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddSingleton<ISurveyService, SurveyService>(survey => new SurveyService(new SurveyRepository(new MySQLStream<Survey>()), new AnswerService(new AnswerRepository(new MySQLStream<Answer>()), new QuestionService(new QuestionRepository(new MySQLStream<Question>())))));
            services.AddSingleton<IAnswerService, AnswerService>(answer => new AnswerService(new AnswerRepository(new MySQLStream<Answer>()), new QuestionService(new QuestionRepository(new MySQLStream<Question>()))));

            services.AddControllers();
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
