using Application.Interfaces;
using Application.Models.Response.Usuario;
using Application.Validators.Utils;
using AutoMapper;
using Domain2.DTO.Correios;
using Domain2.Interfaces;

namespace Application.Controllers
{
    public class UtilsApp : IUtilsApp
    {
        protected readonly IUtilsService UtilsService;
        protected readonly IUtilsValidator UtilsValidation;
        protected readonly IMapper Mapper;

        public UtilsApp(IUtilsService utilsService, IUtilsValidator utilsValidation, IMapper mapper)
        {
            UtilsService = utilsService;
            UtilsValidation = utilsValidation;
            Mapper = mapper;
        }

        public EnderecoResponse ConsultarEnderecoCep(string cep)
        {
            var validation = UtilsValidation.ValidarCep(cep);

            if (!validation.IsValid())
                return Mapper.Map<EnderecoResponse>(validation);

            var retorno = UtilsService.ConsultarEnderecoCep(cep).Result;

            return new EnderecoResponse()
            {
                Estado = retorno.uf,
                Bairro = retorno.bairro,
                Cidade = retorno.localidade,
                Rua = retorno.logradouro,
                StatusApi = retorno.StatusApi
            };
        }
    }
}