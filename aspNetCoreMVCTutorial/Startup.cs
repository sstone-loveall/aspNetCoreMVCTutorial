﻿using aspNetCoreMVCTutorial.Repository;
using aspNetCoreMVCTutorial.Repository.EntityFramework;
using aspNetCoreMVCTutorial.Repository.Impl;
using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.Service.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspNetCoreMVCTutorial
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			// DI
			AddDependencyInjection(services);

			// DB context initialize
			InitializeDbContext(services);

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseStatusCodePages();
				app.UseStaticFiles();
				app.UseAuthentication();

				// configure MVC routes last
				ConfigureCustomRoutes(app);
			}

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}

		public void InitializeDbContext(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(
				options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
		}

		public void ConfigureCustomRoutes(IApplicationBuilder app)
		{
			app.UseMvc(routes => 
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}"
					);
			});
		}

		public void AddDependencyInjection(IServiceCollection services)
		{
			services.AddTransient<IPieRepository, PieRepository>();
			services.AddTransient<IFeedbackRepository, FeedbackRepository>();
			services.AddTransient<IPieService, PieService>();
			services.AddTransient<IFeedbackService, FeedbackService>();
			services.AddTransient<IAuthenticationService, AuthenticationService>();
			services.AddTransient<IUserService, UserService>();
		}
	}
}