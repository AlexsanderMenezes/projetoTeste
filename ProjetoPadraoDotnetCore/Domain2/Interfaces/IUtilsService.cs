using System.Threading.Tasks;
using Domain.DTO.Correios;
using Infraestrutura.Entity;

namespace Domain.Interfaces
{
     public interface IUtilsService
     {
          Task<EnderecoExternalReponse> ConsultarEnderecoCep(string cep);
     }
}