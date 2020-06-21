using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorreiosSearchRest.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorreiosSearchRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {

        public CepController()
        {

        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> Index([FromRoute]string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return Error("Informe o CEP a ser consultado");

            try
            {
                var correios = new Correios.AtendeClienteClient();

                var consulta = await correios.consultaCEPAsync(cep.Replace("-", ""));

                var response = consulta?.@return != null ? ConsultaCepModel.FromCorreiosResponse(consulta) : throw new Exception("Erro buscando CEP");

                return StatusCode(200, response);
            } catch(Exception ex)
            {
                return Error($"Erro ao consultar o cep informado: {ex.Message}");
            }
            
        }

        private IActionResult Error(string message)
        {
            return BadRequest(new { erro = message });
        }
    }
}