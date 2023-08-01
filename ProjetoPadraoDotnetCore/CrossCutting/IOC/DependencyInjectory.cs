using Application1.Authentication;
using Application1.Controllers;
using Application1.Interfaces;
using Application1.Utils.Email;
using Application1.Utils.HashCripytograph;
using Application1.Utils.ValidatorDocument;
using Application1.Validators.Usuario;
using Application1.Validators.Utils;
using Domain2.Interfaces;
using Domain2.Services;
using Infraestrutura.DataBaseContext;
using Infraestrutura.Repository.External;
using Infraestrutura.Repository.Interface.Base;
using Infraestrutura.Repository.Interface.SkillUsuario;
using Infraestrutura.Repository.Interface.Usuario;
using Infraestrutura.Repository.ReadRepository;
using Infraestrutura.Repository.WriteRepository;
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
                o.UseSqlServer(@"Data Source=DESKTOP-0M0JUPL\SQLSA;Initial Catalog=ProjetoPadraoDotnet;User Id=sa;Password=megawere;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"), ServiceLifetime.Transient);
            
        }
    }
}
