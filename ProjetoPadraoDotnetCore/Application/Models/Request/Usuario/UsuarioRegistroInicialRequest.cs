using Infraestrutura.Enum;

namespace Application.Models.Request.Usuario
{
    public class UsuarioRegistroInicialRequest
    {
        //Futuro cadastro inicial agil
        public string Nome { get; set; } = null;
        public string Email { get; set; } = null;
        public string Senha { get; set; } = null;
        public string CPF { get; set; } = null;
        public EGenero Genero { get; set; }
    }
}