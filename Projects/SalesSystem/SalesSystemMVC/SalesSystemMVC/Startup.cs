﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SalesSystemMVC.Data;
using SalesSystemMVC.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;

namespace SalesSystemMVC
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

		    services.AddDbContext<SalesSystemMVCContext>(options =>
					options.UseMySql(Configuration.GetConnectionString("SalesSystemMVCContext"), builder =>
					builder.MigrationsAssembly("SalesSystemMVC")));

			services.AddScoped<SeedingService>();
			services.AddScoped<SellerService>();
			services.AddScoped<DepartmentService>();
			services.AddScoped<SalesRecordService>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService)
		{
			var enUS = new CultureInfo("en-US");
			var localisationOption = new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture(enUS),
				SupportedCultures = new List<CultureInfo> { enUS},
				SupportedUICultures = new List<CultureInfo> { enUS}
			};

			app.UseRequestLocalization(localisationOption);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				seedingService.Seed();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
