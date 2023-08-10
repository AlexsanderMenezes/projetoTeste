using Application.Models.Response.Auth;
using Application.Utils.Objeto;

namespace Application.Models.Response.Usuario
{
    public class UsuarioCadastroInicialResponse
    {
        public LoginResponse DataUsuario { get; set; } = null;
        public ValidationResult Validacao { get; set; } = null;
    }
}