using Findit.API.Services.BookmarkService;
using Microsoft.Extensions.DependencyInjection;

namespace Findit.API.Infrastructure.Services
{
    public static class BootstrapServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IBookmarkService, BookmarkService>();
        }
    }
}