using System;
using System.Linq;
using Application1.Authentication;
using Application1.Interfaces;
using Application1.Models.Request.Login;
using Application1.Models.Request.Senha;
using Application1.Models.Request.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste.Controllers.Base;

namespace teste.Controllers
{

    [Route("[controller]")]
    public class AuthController : DefaultController
    {
        protected readonly IAuthApp AuthApp;
        protected readonly IJwtTokenAuthentication Token;
        protected readonly IUsuarioApp UsuarioApp;


        public AuthController(IAuthApp authApp, IJwtTokenAuthentication token, IUsuarioApp usuarioApp)
        {
            AuthApp = authApp;
            Token = token;
            UsuarioApp = usuarioApp;
        }
        
        [HttpPost("Login")]
        public JsonResult Login([FromBody]LoginRequest request)
        {
            try
            {
                var retorno = AuthApp.Login(request);

                if (!retorno.Autenticado)
                    return ResponderErro("Usuário ou senha inválido!");

                return ResponderSucesso(retorno);
            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }

        [HttpPost("GerarToken")]
        public JsonResult GerarToken(TokenRequest request)
        {
            try
            {
                var usuario = UsuarioApp.GetByCpf(request.Cpf);

                if (usuario == null)
                    return ResponderErro("Não foi encontrado usuário com este CPF!");

                var retorno = Token.GerarToken(request.Cpf);

                return ResponderSucesso(retorno);
            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }

        [HttpPost]
        //[Authorize]
        [Route("AlterarSenha")]
        public JsonResult AlterarSenha(UsuarioAlterarSenhaRequest request)
        {
            try
            {
                var retorno = UsuarioApp.AlterarSenha(request);

                if (!retorno.IsValid())
                    return ResponderErro(retorno.LErrors.FirstOrDefault());

                return ResponderSucesso("Senha Alterada com sucesso");
            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }

    }
}