using Coolsprings.Contract;
using CoolSprings.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using CoolSprings.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using MyFirstAPI.Services;
using CoolSprings.Contract.Repository;
using CoolSprings.Validator.DTO;

namespace CoolSprings.API
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
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IExceptionRepository, ExceptionRepository>();
            services.AddScoped<IEnquiryRepository, EnquiryRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IEncoding, EncodingService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<TokenCredentialDTOValidator>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                // TO generate docs from the comments
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // mandatory swagger config
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CoolSprings API",
                    Version = "v1",
                    Description = "CoolSprings Waterpark Backend API",
                    Contact = new OpenApiContact()
                    {
                        Name = "Sakshi Gupta",
                        Email = "sakshi@gmail.com"
                    },
                    License = new OpenApiLicense()
                    { Name = "Private Property" }
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoolSprings API");
                c.RoutePrefix = string.Empty; 
            });

            app.UseAuthorization();
            app.UseCors("AllowAll");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}