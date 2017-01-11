using Findit.API.Configuration;
using Findit.API.Infrastructure.Automapper;
using Findit.API.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Findit.API.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace Findit.API
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc(options =>
			{
				options.Filters.Add(new GlobalExceptionFilter());
			});

			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
			});

			services.AddOptions();
			services.Configure<DatabaseSettings>(options => Configuration.GetSection("DatabaseSettings").Bind(options));

			//bootstrap automapper
			services.AddAutomapper();
			//bootstrap services
			services.AddServices();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseCors("AllowAll");

			var options = new JwtBearerOptions
			{
				Audience = Configuration["Auth0:ClientId"],
				Authority = Configuration["Auth0:Authority"]
			};

			app.UseJwtBearerAuthentication(options);

			app.UseMvc();
		}
	}
}
