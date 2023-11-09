using System;
using System.IO;
using System.Text;
using Application.AutoMapper;
using AutoMapper;
using CrossCutting.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace teste
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // requires Microsoft.Extensions.Configuration.Json
                .AddJsonFile("appsettings.json") // requires Microsoft.Extensions.Configuration.Json
                .AddEnvironmentVariables(); // requires Microsoft.Extensions.Configuration.EnvironmentVariables
            Configuration = builder.Build();
        }

        protected IConfiguration Configuration { set; get; }

        public void ConfigureServices(IServiceCollection services)
        {
        
            //gambs do swagger ???
            services.AddMvcCore().AddApiExplorer();
            services.AddMvc();

            //instancia autoMapper
            services.AddAutoMapper(typeof(Mapping));
        
            services.Injectory(services, Configuration);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Logging:TokenConfigurations:Key"])),
                    ClockSkew = TimeSpan.Zero
                });


            // Registrar o gerador do Swagger, definindo um ou mais documentos Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
                { 
                    Name = "Authorization", 
                    Type = SecuritySchemeType.ApiKey, 
                    Scheme = "Bearer", 
                    BearerFormat = "JWT", 
                    In = ParameterLocation.Header, 
                    Description = "JWT Authorization header using the Bearer scheme.", 
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("*")
                .WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
            );
            
            // Middleware da autenticação JWT
            app.UseAuthentication();
            
            // Middleware do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API WEB");
            });
            
            app.UsePathBase("/ProjetoPadraoDotnetCore/Web2");
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "DefaultApi",
                    "ProjetoPadraoDotnetCore/Web/{controller}/{action}/{id}"
                );
            });
            
        
            app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
        }
    }
}