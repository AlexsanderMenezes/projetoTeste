using Application.Utils.Objeto;

namespace Application.Models.Response.Usuario
{
    public class EnderecoResponse 
    {
        public string Cidade { get; set; } = null;
        public string Estado { get; set; } = null;
        public string Bairro { get; set; } = null;
        public string Rua { get; set; } = null;
        public bool StatusApi { get; set; }
    }
}