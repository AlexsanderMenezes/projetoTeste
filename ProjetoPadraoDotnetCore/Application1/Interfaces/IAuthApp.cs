using Aplication.Models.Request.Login;
using Aplication.Models.Response.Auth;
using Aplication.Utils.Objeto;
using Infraestrutura.Entity;

namespace Aplication.Interfaces
{
     public interface IAuthApp
     {
          LoginResponse Login(LoginRequest request, bool isRecuperacaoSenha = false);
     }
}