// using System;
// using System.Collections.Generic;
// using Application.Authentication;
// using Application.Interfaces;
// using Application.Models.Request.Login;
// using Microsoft.AspNetCore.Mvc;
// using teste.Controllers.Base;
//
// namespace teste.Controllers
// {
//     [Route("api/[controller]")]
//     public class ValuesController : DefaultController
//     {
//         protected readonly IAuthApp AuthApp;
//         protected readonly IJwtTokenAuthentication Token;
//         protected readonly IUsuarioApp UsuarioApp;
//
//
//         public ValuesController(IAuthApp authApp, IJwtTokenAuthentication token, IUsuarioApp usuarioApp)
//         {
//             AuthApp = authApp;
//             Token = token;
//             UsuarioApp = usuarioApp;
//         }
//         
//         // GET api/values
//         [HttpGet]
//         public IEnumerable<string> Get()
//         {
//             return new string[] {"value1", "value2"};
//         }
//
//         // GET api/values/5
//         [HttpGet("{id}")]
//         public string Get(int id)
//         {
//             return "value";
//         }
//
//         // POST api/values
//         [HttpPost("Login")]
//         public JsonResult Login([FromBody] LoginRequest request)
//         {
//             try
//             {
//                 var retorno = AuthApp.Login(request);
//
//                 if (!retorno.Autenticado)
//                     return ResponderErro("Usuário ou senha inválido!");
//
//                 return ResponderSucesso(retorno);
//             }
//             catch (Exception e)
//             {
//                 return ResponderErro(e.Message);
//             }
//         }
//
//         // PUT api/values/5
//         [HttpPut("{id}")]
//         public void Put(int id, [FromBody] string value)
//         {
//         }
//
//         // DELETE api/values/5
//         [HttpDelete("{id}")]
//         public void Delete(int id)
//         {
//         }
//     }
// }