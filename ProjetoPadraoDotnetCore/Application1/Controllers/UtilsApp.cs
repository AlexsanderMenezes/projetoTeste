using Application1.Interfaces;
using Application1.Models.Response.Usuario;
using Application1.Validators.Utils;
using AutoMapper;
using Domain2.DTO.Correios;
using Domain2.Interfaces;

namespace Application1.Controllers
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

            return Mapper.Map<EnderecoExternalReponse, EnderecoResponse>(retorno);
        }
    }
}