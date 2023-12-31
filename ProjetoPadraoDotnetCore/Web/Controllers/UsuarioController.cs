using System;
using System.Linq;
using Application.Interfaces;
using Application.Models.Request.Usuario;
using Application.Models.Response.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste.Controllers.Base;

namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : DefaultController
    {
        protected readonly IUsuarioApp App;

        public UsuarioController(IUsuarioApp usuarioApp)
        {
            App = usuarioApp;
        }

        [HttpPost]
        //implementar futuro primeiro cadastro
        [Route("Cadastrar")]
        public JsonResult Cadastrar(UsuarioRequest request)
        {
            try
            {
                var cadastro = App.Cadastrar(request);

                if (cadastro.IsValid())
                    return ResponderSucesso("Usuário cadastrado com sucesso!");

                return ResponderErro(cadastro.LErrors.FirstOrDefault());

            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }
        
        [HttpPost]
        //implementar futuro primeiro cadastro
        [Route("CadastroInicial")]
        public JsonResult CadastrarInicial(UsuarioRegistroInicialRequest request)
        {
            try
            {
                var cadastro = App.CadastroInicial(request);

                if (cadastro.IsValid())
                    return ResponderSucesso("Usuário cadastrado com sucesso!");

                return ResponderErro(cadastro.LErrors.FirstOrDefault());

            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("ConsultarTodos")]
        public JsonResult ConsultarTodos()
        {
            try
            {
                var objeto = new UsuarioResponse()
                {
                    itens = App.GetAll()
                };

                return ResponderSucesso(objeto);
            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("ConsultarViaId/{id}")]
        public JsonResult ConsultarViaId(int id)
        {
            try
            {
                return ResponderSucesso(App.GetById(id));
            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }


        [HttpPost]        
        [Authorize]
        [Route("Editar")]
        public JsonResult Editar(UsuarioRequest request)
        {
            try
            {
                var edicao = App.Editar(request);

                if (edicao.IsValid())
                    return ResponderSucesso("Usuário editado com sucesso!");

                return ResponderErro(edicao.LErrors.FirstOrDefault());
            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("DeleteById")]
        public JsonResult DeleteById(int id)
        {
            try
            {
                App.DeleteById(id);
                return ResponderSucesso("Usuário deletado com sucesso!");
            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("ConsultarGridUsuario")]
        public JsonResult ConsultarGridUsuario()
        {
            try
            {
                var retorno = App.ConsultarGridUsuario();

                return ResponderSucesso(retorno);
            }
            catch (Exception e)
            {
                return ResponderErro("Implementação futura + front");
            }
        }

    }
}