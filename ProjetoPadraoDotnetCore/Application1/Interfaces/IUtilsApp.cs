using Application1.Models.Response.Usuario;

namespace Application1.Interfaces
{
    public interface IUtilsApp
    {
         EnderecoResponse ConsultarEnderecoCep(string cep);
    }
}