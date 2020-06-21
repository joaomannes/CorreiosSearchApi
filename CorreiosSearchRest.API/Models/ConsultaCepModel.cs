using Correios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreiosSearchRest.API.Models
{
    public class ConsultaCepModel
    {
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public static ConsultaCepModel FromCorreiosResponse(consultaCEPResponse response)
        {
            return new ConsultaCepModel
            {
                Bairro = response.@return.bairro,
                Cep = response.@return.cep,
                Cidade = response.@return.cidade,
                Complemento = response.@return.complemento2,
                Endereco = response.@return.end,
                Uf = response.@return.uf
            };
        }
    }
}
