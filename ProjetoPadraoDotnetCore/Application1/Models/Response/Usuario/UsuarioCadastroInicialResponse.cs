using Application1.Models.Response.Auth;
using Application1.Utils.Objeto;

namespace Application1.Models.Response.Usuario
{
    public class UsuarioCadastroInicialResponse
    {
        public LoginResponse DataUsuario { get; set; } = null;
        public ValidationResult Validacao { get; set; } = null;
    }
}