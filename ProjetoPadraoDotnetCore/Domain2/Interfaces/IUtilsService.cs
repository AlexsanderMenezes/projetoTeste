using System.Threading.Tasks;
using Domain2.DTO.Correios;

namespace Domain2.Interfaces
{
     public interface IUtilsService
     {
          Task<EnderecoExternalReponse> ConsultarEnderecoCep(string cep);
     }
}