using System.Collections.Generic;
using System.IO;
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
            
            var tokenKey = "ProjetoPadraoDotnet"; // Troque pela sua chave secreta
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "seu_issuer",
                        ValidAudience = "seu_audience",
                        IssuerSigningKey = key
                    };
                });

            
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
                // Definir o esquema de segurança Bearer Token
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                // Adicionar a exigência de autenticação globalmente para todas as operações
                var securityRequirement = new OpenApiSecurityRequirement
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
                        new List<string>()
                    }
                };

                c.AddSecurityRequirement(securityRequirement); 
                
            //     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //     {
            //         Description =
            //             "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            //         Name = "Authorization",
            //         In = ParameterLocation.Header,
            //         Type = SecuritySchemeType.ApiKey,
            //         Scheme = "Bearer"
            //     });
            //
            //     c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //     {
            //         {
            //             new OpenApiSecurityScheme
            //             {
            //                 Reference = new OpenApiReference
            //                 {
            //                     Type = ReferenceType.SecurityScheme,
            //                     Id = "Bearer"
            //                 },
            //                 Scheme = "oauth2",
            //                 Name = "Bearer",
            //                 In = ParameterLocation.Header,
            //
            //             },
            //             new List<string>()
            //         }
            //     });
            // });
            //
            // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ProjetoPadraoDotnet"));
            // services.AddAuthentication(authOptions =>
            // {
            //     authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // }).AddJwtBearer("Bearer", options =>
            // {
            //     //paramns para utilização do token
            //     options.Audience = "8d708afe-2966-40b7-918c-a39551625958";
            //     options.Authority = "https://login.microsoftonline.com/a1d50521-9687-4e4d-a76d-ddd53ab0c668/";
            //     options.RequireHttpsMetadata = false;
            //     options.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey = true,
            //         ValidateLifetime = true,
            //         IssuerSigningKey = key,
            //         ValidateAudience = false,
            //         ValidateIssuer = false
            //     };
             });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            
            app.UseAuthentication();

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