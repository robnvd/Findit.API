using AutoMapper;
using Findit.API.Infrastructure.Automapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Findit.API.Infrastructure.Automapper
{
    public static class AutomapperBootstraper
    {
        private static MapperConfiguration _mapperConfiguration;

        public static void AddAutomapper(this IServiceCollection services)
        {
            _mapperConfiguration = GetConfiguration();
            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
        }

        private static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookmarksProfile>();
                cfg.AddProfile<PlacesProfile>();
                cfg.AddProfile<ReviewsProfile>();
            });
        }
    }
}