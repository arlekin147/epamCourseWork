using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Training.Servises;
using Training.ViewModels;
using Training.Models;
using Training.Repositories;
using Training.AutoMapper;
using Training.Utils;
using Swashbuckle.AspNetCore.Swagger;

namespace ASPDemo
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
            var path = @"C:\Users\14714\source\repos\M20\Training\config.xml";
            services.AddSingleton(new Config(path));
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            services.AddLogging();

            services.AddScoped<IRepository<Student>, StudentRepository>();
            services.AddScoped<IService<StudentViewModel>, StudentService>();

            services.AddScoped<IRepository<Lector>, LectorRepository>();
            services.AddScoped<IService<LectorViewModel>, LectorServise>();

            services.AddScoped<IRepository<Course>, CourseRepository>();
            services.AddScoped<IService<CourseViewModel>, CourseServise>();

            services.AddScoped<IRepository<Lection>, LectionRepository>();
            services.AddScoped<IService<LectionViewModel>, LectionServise>();

            services.AddScoped<ITwoKeysRepository<Score>, ScoreRepository>();
            services.AddScoped<ITwoIdService<ScoreViewModel>, ScoreService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
