using System;
using System.Linq;
using Application1.Interfaces;
using Application1.Models.Request.Usuario;
using Application1.Models.Response.Usuario;
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


        [HttpGet]
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

        [HttpPost]
        [Route("ConsultarGridUsuario")]
        public JsonResult ConsultarGridUsuario(UsuarioGridRequest request)
        {
            try
            {
                var retorno = App.ConsultarGridUsuario(request);

                return ResponderSucesso(retorno);
            }
            catch (Exception e)
            {
                return ResponderErro("Implementação futura + front");
            }
        }

    }
}