using System.Linq;
using Application.Authentication;
using Application.Interfaces;
using Application.Models.Request.Login;
using Application.Models.Response.Auth;
using Application.Utils.Email;
using Application.Utils.HashCripytograph;
using Domain2.Interfaces;
using Infraestrutura.Entity;
using Infraestrutura.Enum;
using Microsoft.Extensions.Configuration;

namespace Application.Controllers
{
    public class AuthApp : IAuthApp
    {
        protected readonly IEmailHelper EmailHelper;
        protected readonly IUsuarioService UsuarioService;
        protected readonly IHashCriptograph Crypto;
        protected readonly IJwtTokenAuthentication Jwt;
        private readonly IConfiguration _configuration;

        public AuthApp(IUsuarioService usuarioService, IHashCriptograph crypto, IJwtTokenAuthentication jwt,
            IConfiguration configuration, IEmailHelper emailHelper)
        {
            UsuarioService = usuarioService;
            Crypto = crypto;
            Jwt = jwt;
            _configuration = configuration;
            EmailHelper = emailHelper;
        }

        public LoginResponse Login(LoginRequest request, bool isRecuperacaoSenha = false)
        {
            var retorno = new LoginResponse();

            Usuario usuario;

            if (isRecuperacaoSenha)
            {
                usuario = UsuarioService.GetAllList()
                    .FirstOrDefault(x => x.Email == request.EmailLogin && x.Senha ==
                        request.SenhaLogin);
            }
            else
            {
                usuario = UsuarioService.GetAllList()
                    .FirstOrDefault(x => x.Email == request.EmailLogin);
            }


            if (usuario == null)
                retorno.Autenticado = false;
            else
            {
                retorno.Autenticado = true;
                retorno.Nome = usuario.Nome;
                retorno.SessionKey = Jwt.GerarToken(usuario.Cpf);
                retorno.IdUsuario = usuario.IdUsuario;
                retorno.Perfil = usuario.PerfilAdministrador;
            }

            return retorno;
        }
    }
}