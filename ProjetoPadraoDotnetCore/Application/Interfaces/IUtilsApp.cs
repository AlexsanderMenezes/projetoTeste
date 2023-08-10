using Application.Models.Response.Usuario;

namespace Application.Interfaces
{
    public interface IUtilsApp
    {
         EnderecoResponse ConsultarEnderecoCep(string cep);
    }
}