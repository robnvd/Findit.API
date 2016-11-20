using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Findit.API.Configuration;
using Findit.API.Infrastructure.Automapper;
using Findit.API.Infrastructure.Services;
using Findit.API.Services.BookmarkService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stormpath.AspNetCore;
using Stormpath.Configuration.Abstractions;

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
			var stormpathConfig = Configuration.Get<Stormpath>("Stormpath");
			services.AddStormpath(new StormpathConfiguration
			{
				Application = new ApplicationConfiguration
				{
					Href = stormpathConfig.AppHref,
					Name = stormpathConfig.AppName
				},
				Client = new ClientConfiguration
				{
					ApiKey = new ClientApiKeyConfiguration
					{
						Id = stormpathConfig.ClientId,
						Secret = stormpathConfig.ClientSecret
					}
				},
				Web = new WebConfiguration
				{
					VerifyEmail = new WebVerifyEmailRouteConfiguration
					{
						Enabled = false
					}
				}
			});

			// Add framework services.
			services.AddMvc(options =>
			{
				options.Filters.Add(new GlobalExceptionFilter());
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

			app.UseStormpath();

			app.UseMvc();
		}
	}
}
