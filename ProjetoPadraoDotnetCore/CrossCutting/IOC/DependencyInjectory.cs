﻿using Aplication.Authentication;
using Aplication.Controllers;
using Aplication.Interfaces;
using Aplication.Utils.Email;
using Aplication.Utils.HashCripytograph;
using Aplication.Utils.ValidatorDocument;
using Aplication.Validators.Usuario;
using Aplication.Validators.Utils;
using Application1.Controllers;
using Application1.Interfaces;
using Domain.Interfaces;
using Domain.Services;
using Domain2.Interfaces;
using Infraestrutura.DataBaseContext;
using Infraestrutura.Repository.External;
using Infraestrutura.Repository.Interface.Base;
using Infraestrutura.Repository.Interface.SkillUsuario;
using Infraestrutura.Repository.Interface.Usuario;
using Infraestrutura.Repository.ReadRepository;
using Infraestrutura.Repository.WriteRepository;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IOC
{
    public static class DependencyInjectory
    {
        public static void Injectory(this IServiceCollection services, IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            #region Utils
            services.AddTransient<IHashCriptograph, HashCripytograph>();
            services.AddTransient<IValidatorDocument, ValidatorDocument>();
            services.AddTransient<IJwtTokenAuthentication, JwtAuthentication>();
            services.AddScoped<IEmailHelper, EmailHelper>();
            #endregion

            #region Validators
            services.AddTransient<IUsuarioValidator, UsuarioValidator>();
            services.AddTransient<IUtilsValidator,UtilsValidatior>();
            #endregion

            #region Aplicação
            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IAuthApp, AuthApp>();
            services.AddScoped<IUtilsApp, UtilsApp>();
            #endregion

            #region Domínio
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUtilsService, UtilService>();
            #endregion

            #region Repositorio
            services.AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>));
            services.AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>));
            services.AddScoped<IUsuarioReadRepository, UsuarioReadRepository>();
            services.AddScoped<IUsuarioWriteRepository, UsuarioWriteRepository>();
            services.AddScoped<IExternalRepository, ExternalRepository>();
            services.AddScoped<ISkillUsuarioReadRepository, SkillUsuarioReadRepository>();
            services.AddScoped<ISkillUsuarioWriteRepository, SkillUsuarioWriteRepository>();
            services.AddScoped<IUsuarioReadRepository, UsuarioReadRepository>();
            #endregion

            //Context onde instancia a conexão com o banco
            services.AddDbContext<Context>(o => 
                o.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]), ServiceLifetime.Transient);
            
        }
    }
}
