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
                return BadRequest("Informe o CEP a ser consultado");

            try
            {
                var correios = new Correios.AtendeClienteClient();

                var consulta = await correios.consultaCEPAsync(cep.Replace("-", ""));

                var response = ConsultaCepModel.FromCorreiosResponse(consulta);

                return Ok(response);
            } catch(Exception ex)
            {
                return BadRequest($"Erro ao consultar o cep informado: {ex.Message}");
            }
            
        }
    }
}