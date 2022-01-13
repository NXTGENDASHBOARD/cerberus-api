using Cerberus.Dashboard.Api.Authorize;
using Cerberus.Dashboard.Api.Filters;
using Cerberus.Dashboard.Api.IoC;
using Cerberus.Dashboard.Application.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Cerberus.Dashboard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddNewtonsoftJson()
                .AddJsonOptions(x =>
                {
                    // serialize enums as strings in api responses (e.g. Role)
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            ContainerSetup.Setup(services, Configuration);

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("Security"));
            services.Configure<EmailConfiguration>(Configuration.GetSection("EmailConfiguration"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ITS 5.0 Student Selection API", Version = "v1.0.0" });
                c.DocumentFilter<CustomSwaggerDocumentAttribute>();
                c.OperationFilter<CustomSwaggerHeaderAttribute>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ITS 5.0 Student Selection API v1.0.0"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles(); // Helps with file management

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
