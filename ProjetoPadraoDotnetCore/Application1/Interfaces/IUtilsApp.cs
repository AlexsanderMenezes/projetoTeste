using Aplication.Models.Response.Usuario;

namespace Aplication.Interfaces
{
    public interface IUtilsApp
    {
         EnderecoResponse ConsultarEnderecoCep(string cep);
    }
}