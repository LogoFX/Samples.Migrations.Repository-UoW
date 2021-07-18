using System.Diagnostics.CodeAnalysis;
using LogoFX.Data.DbContext.AdoDotNet;
using LogoFX.Data.Repository;
using LogoFX.Data.Repository.AdoDotNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Samples.Server.Data.Context.AdoDotNet;
using Samples.Server.Domain.Contracts;
using Samples.Server.Domain.Implementation.Services;

namespace Samples.Server.GraphQL.Facade
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")] 
        public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<ICourtsService, CourtsService>()
					.AddSingleton<IUnitOfWork, UnitOfWork>()
					.AddSingleton<IDbContext, AppDbContext>()
					.AddTransient<ITransactionFactory, TransactionConcreteFactory>()
					.AddTransient<IDbContextFactory, DbContextFactory>()
                    .AddSingleton<IConnectionStringService, ConnectionStringService>()
					.AddGraphQLServer()
					.AddQueryType<Query>();
			services.AddRazorPages();
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
