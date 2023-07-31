using System.Net;

namespace Domain2.DTO.Correios
{
    public class EnderecoExternalReponse
    {
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public bool StatusApi { get; set; } = true;
        public HttpStatusCode? StatusCode { get; set; }
    }
}