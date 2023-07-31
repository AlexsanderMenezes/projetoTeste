using Application1.Models.Request.Login;
using Application1.Models.Response.Auth;

namespace Application1.Interfaces
{
     public interface IAuthApp
     {
          LoginResponse Login(LoginRequest request, bool isRecuperacaoSenha = false);
     }
}