using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using survey_server.Infra;
using survey_server.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace survey_server
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
            services.AddControllers();

            services.AddDbContext<SurveyContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("SurveyDbConnection")));

            services.AddScoped<ISurveyService, SurveyService>();

            services.AddHostedService<RunMigration>();

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

    public class RunMigration : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public RunMigration(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetService<SurveyContext>()
                    .Database.Migrate();
            }

            return Task.CompletedTask;
        }
    }
}
