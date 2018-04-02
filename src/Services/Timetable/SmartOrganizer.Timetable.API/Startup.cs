using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using SmartOrganizer.Timetable.API.Infrastructure;
using SmartOrganizer.Timetable.Services.Directions;
using SmartOrganizer.Timetable.Services.Geocoding;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;

namespace SmartOrganizer.Timetable.API
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
			services
				.AddSingleton<IDirectionsResponseAdapter, DirectionsResponseAdapter>()
				.AddTransient<IGeocodingService, GeocodingService>()
				.AddTransient<IDirectionsService, DirectionsService>();

			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", policy =>
				{
					policy.AllowAnyHeader();
					policy.AllowAnyMethod();
					policy.AllowAnyOrigin();
					policy.AllowCredentials();
				});
			});

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
			var identityUrl = Configuration.GetValue<string>("IdentityUrl");

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

			}).AddJwtBearer(options =>
			{
				options.Authority = identityUrl;
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
			});

			services.AddMvc();

			services.AddDbContext<TimetableContext>(options =>
			{
				options.UseSqlServer(Configuration["ConnectionString"], sqlServerOptionsAction: sqlOptions =>
				{
					sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
					sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30),
						errorNumbersToAdd: null);
				});

				options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
			});

			services.AddSwaggerGen(s =>
			{
				s.SwaggerDoc("v1", new Info
				{
					Title = "Timetable API",
					Version = "v1",
					Contact = new Contact
					{
						Name = "Oleh Dutsiak",
						Email = "oleg.dystak@gmail.com",
						Url = "https://github.com/drru97/smartorganizer/"
					}
				});

				// enable xml comments for swagger
				var basePath = PlatformServices.Default.Application.ApplicationBasePath;
				var xmlPath = Path.Combine(basePath, "Timetable.API.xml");
				s.IncludeXmlComments(xmlPath);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(s =>
			{
				s.SwaggerEndpoint("/swagger/v1/swagger.json", "Timetable API v1");
			});

			app.UseCors("AllowAll");
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
