using LEMV.Application.Services;
using LEMV.Application.Services.Interfaces;
using LEMV.Data.Repositories;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using LEMV.Domain.Notifications;
using LEMV.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LEMV.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
                                                                Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            //Injeção de Dependência            
            services.AddScoped<INotificator, Notificator>();


            services.AddScoped<INewsAppService, NewsAppService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsRepository, NewsRepository>();

            services.AddScoped<IProjectAppService, ProjectAppService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IMaterialAppService, MaterialAppService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();

            services.AddScoped<IBookAppService, BookAppService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IArtifactAppService, ArtifactAppService>();
            services.AddScoped<IArtifactService, ArtifactService>();
            services.AddScoped<IArtifactRepository, ArtifactRepository>();

            services.AddScoped<ISkillsAppService, SkillsAppService>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<ISkillsRepository, SkillsRepository>();

            services.AddTransient<IFilesAppService, FilesAppService>();
            services.AddTransient<IFilesService, FilesService>();
            services.AddTransient<IFilesRepository, FilesRepository>();

            //AD Config
            var section = configuration.GetSection("ActiveDirectory");
            services.Configure<ActiveDirectory>(section);

            return services;
        }
    }
}