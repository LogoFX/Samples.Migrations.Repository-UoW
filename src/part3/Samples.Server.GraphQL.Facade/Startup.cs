using JetBrains.Annotations;
using LogoFX.Data.Repository;
using LogoFX.Server.Bootstrapping.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ngcs.Server.GraphQL.Facade;
using Solid.Bootstrapping;
using BootstrapperBase = LogoFX.Server.Bootstrapping.BootstrapperBase;

namespace Samples.Server.GraphQL.Facade
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
        }

        [UsedImplicitly]
		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringService, ConnectionStringService>();

			services.AddGraphQLServer()
					.AddQueryType<Query>();
			services.AddRazorPages();

            var bootstrapper = new Bootstrapper(services)
                .Use(new RegisterCustomCompositionModulesMiddleware<BootstrapperBase, IServiceCollection>())
                .Use(new RegisterCoreMiddleware<BootstrapperBase>())
                .Use(new RegisterControllersMiddleware<BootstrapperBase>());
            bootstrapper.Initialize();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles()
				.UseRouting()
				.UseAuthorization()
				.UseEndpoints(endpoints =>
					{
						endpoints.MapRazorPages();
					})
				.UseEndpoints(endpoints =>
				{
					endpoints.MapGraphQL();
				});
		}
    }
}
