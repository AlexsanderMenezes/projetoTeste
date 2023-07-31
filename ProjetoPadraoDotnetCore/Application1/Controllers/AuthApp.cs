using System.Linq;
using Application1.Authentication;
using Application1.Interfaces;
using Application1.Models.Request.Login;
using Application1.Models.Response.Auth;
using Application1.Utils.Email;
using Application1.Utils.HashCripytograph;
using Domain2.Interfaces;
using Infraestrutura.Entity;
using Infraestrutura.Enum;
using Microsoft.Extensions.Configuration;

namespace Application1.Controllers
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
                retorno.Foto = usuario.Foto == null
                    ? usuario.Genero == EGenero.Masculino
                        ? _configuration.GetSection("ImageDefaultUser:Masculino").Value
                        : _configuration.GetSection("ImageDefaultUser:Feminino").Value
                    : usuario.Foto;
                retorno.Perfil = usuario.PerfilAdministrador;
            }

            return retorno;
        }
    }
}