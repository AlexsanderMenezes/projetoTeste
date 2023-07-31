using System.Collections.Generic;
using System.Text;
using Application1.AutoMapper;
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

namespace Web2
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
        
            //gambs do swagger ???
            services.AddMvcCore().AddApiExplorer();
        
            //instancia autoMapper
            services.AddAutoMapper(typeof(Mapping));
        
            services.Injectory(services, Configuration);



            // Registrar o gerador do Swagger, definindo um ou mais documentos Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Projeto Padrão",
                    Version = "v1",
                    Description = "Aplicação Projeto Padrão"
                });
                // autenticação do JWT 
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
            });
            
            

        
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ProjetoPadraoDotnet"));
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", options =>
            {
                //paramns para utilização do token
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UsePathBase("/ProjetoPadraoDotnetCore/Web2");
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "DefaultApi",
                    "ProjetoPadraoDotnetCore/Web2/{controller}/{action}/{id}"
                );
            });
        
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/ProjetoPadraoDotnetCore/Web2/swagger/v1/swagger.json", "API WEB");
            });
        
            app.UseAuthentication();


            app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
        }
    }
}