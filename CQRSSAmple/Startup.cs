using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Business.Operatori;
using CQRSSAmple.Domain.Infrasctructure;
using CQRSSAmple.Domain.Infrasctructure.Authorization;
using CQRSSAmple.Domain.Queries.Serializer.EntityOne;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CQRSSAmple
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            //Configuration = configuration;
            
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO
            //--GESTIRE IL DATABASE
            //--GESTIRE LE MIGRAZIONI
            //--AGGIUNGERE I CONTROLLERS
            //--AGGIUNGERE AUTENTICAZIONE E GESTIONE UTENTI
            //--AGGIUNGERE LOG
            //GESTIONE ERRORI
            //--GESTIONE CONFIGURAZIONI
            //--SWAGGER
            
            services.AddControllers();
            
            services.AddControllers ()
                .AddJsonOptions (o => {
                    o.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "Fiver.Security.Bearer",
                        ValidAudience = "Fiver.Security.Bearer",
                        IssuerSigningKey = JwtSecurityKey.Create("grgpla74a26g284d")
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });
            
            services.AddScoped<IEntityOneSerializer, EntityOneSerializer>();
            services.AddScoped<IEntityOneBusiness, EntityOneBusiness>();
            services.AddScoped<IOperatoriBusiness, OperatoriBusiness>();
            
            //var connString = "Host=localhost;Database=CQRSSample;Username=postgres;Password=secret;Port=5532";

            var connString =(string) Configuration.GetValue(typeof(string), "ConnectionString");
            services.AddDbContext<EntityContext>(options => options.UseNpgsql(connString), ServiceLifetime.Transient);
            //optionsBuilder.UseNpgsql (LibCommons.Configuration.MainDB,
            //    o => o.MigrationsAssembly (typeof (DbEntryPoint).Assembly.GetName ().Name));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CQRSSample", Version = "v1" });
                c.CustomSchemaIds(type => type.ToString());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

                //EventsHandler.RegisterEvents();
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();  
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin.API v1"));
            
            app.UseSerilogRequestLogging();
        }
    }
}