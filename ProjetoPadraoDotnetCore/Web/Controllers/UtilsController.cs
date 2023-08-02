using System;
using Application1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste.Controllers.Base;

namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtilsController : DefaultController
    {
        protected readonly IUtilsApp UtilsApp;

        public UtilsController(IUtilsApp utilApp)
        {
            UtilsApp = utilApp;
        }

        [HttpGet]
        [Route("ConsultarEnderecoCep/{cep}")]
        public JsonResult ConsultarEnderecoCep(string cep)
        {
            try
            {
                var retorno = UtilsApp.ConsultarEnderecoCep(cep);

                if (!retorno.IsValid())
                    return ResponderErro("Cep inválido!");

                return ResponderSucesso(retorno);
            }
            catch (Exception e)
            {
                return ResponderErro(e.Message);
            }
        }
    }
}