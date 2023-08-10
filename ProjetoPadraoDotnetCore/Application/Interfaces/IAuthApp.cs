using Application.Models.Request.Login;
using Application.Models.Response.Auth;

namespace Application.Interfaces
{
     public interface IAuthApp
     {
          LoginResponse Login(LoginRequest request, bool isRecuperacaoSenha = false);
     }
}