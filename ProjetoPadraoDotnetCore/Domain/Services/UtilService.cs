﻿using System.Net;
using System.Threading.Tasks;
using Domain2.DTO.Correios;
using Domain2.Interfaces;
using Infraestrutura.Repository.External;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Domain2.Services
{
    public class UtilService : IUtilsService
    {
        protected readonly IExternalRepository External;


        private readonly IConfiguration _configuration;

        public UtilService(IExternalRepository external, IConfiguration config)
        {
            External = external;
            _configuration = config;
        }

        public async Task<EnderecoExternalReponse> ConsultarEnderecoCep(string cep)
        {
            EnderecoExternalReponse retorno;
            var url = _configuration.GetSection("Logging:ApiCorreios:Link");
            var requisicao = await External.SendWebHttp(url.Value + cep + "/json");

            if (requisicao.StatusCode == HttpStatusCode.OK)
            {
                if (requisicao.ObjetoJson != null)
                {
                    retorno = JsonConvert.DeserializeObject<EnderecoExternalReponse>(requisicao.ObjetoJson)
                              ?? new EnderecoExternalReponse() {StatusApi = false, StatusCode = requisicao.StatusCode};

                    if (string.IsNullOrEmpty(retorno.bairro) || string.IsNullOrEmpty(retorno.localidade) ||
                        string.IsNullOrEmpty(retorno.uf)
                        || string.IsNullOrEmpty(retorno.logradouro))
                    {
                        retorno.StatusApi = false;
                    }

                    return retorno;
                }

            }

            retorno = JsonConvert.DeserializeObject<EnderecoExternalReponse>(requisicao.ObjetoJson)
                      ?? new EnderecoExternalReponse() {StatusApi = false, StatusCode = requisicao.StatusCode};

            if (string.IsNullOrEmpty(retorno.bairro) || string.IsNullOrEmpty(retorno.localidade) ||
                string.IsNullOrEmpty(retorno.uf)
                || string.IsNullOrEmpty(retorno.logradouro))
            {
                retorno.StatusApi = false;
            }

            return retorno;
        }
    }
}