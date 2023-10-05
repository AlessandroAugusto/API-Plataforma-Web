using API_Plataforma_Web.Domain.Dtos;
using API_Plataforma_Web.Domain.Enums;
using API_Plataforma_Web.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Plataforma_Web.Controllers
{
    [Route("plataforma-seguros/v1/[controller]")]
    [ApiController]
    public class DemandaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly ILogger<DemandaController> _logger;

        public DemandaController(
            ILogger<DemandaController> logger,
            ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
            _logger = logger;
        }

        /// <summary>
        /// Realizar busca de tarefas
        /// </summary>
        /// <returns>Favorito encontrado via documento</returns>
        /// <response code="200">Retorna item encontrado</response>
        /// <response code="204">Caso nao encontre nenhum item</response>
        /// <response code="500">Erro interno na api</response>
        [HttpGet("listar")]
        [ProducesResponseType(typeof(ListaTarefasResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(PadraoResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ListaTarefasResponse>> ListarTarefas()
        {
            var response = await _tarefaService.ConsultaDemandaAsync();

            if (response.CodRetorno == CodigoRetorno.Erro)
            {
                return BadRequest(response);
            }
            if (response.ListaTarefas != null)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Gravar a tarefa enviada pela plataforma
        /// </summary>
        /// <param name="request">Parâmetros de entrada para corrigir monetário</param>
        /// <response code="200">Retorna item encontrado</response>
        /// <response code="204">Caso nao encontre nenhum item</response>
        /// <response code="500">Erro interno na api</response>
        /// <returns></returns>
        [HttpPost("gravar")]
        [ProducesResponseType(typeof(PadraoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(PadraoResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PadraoResponse>> GravarTarefas(
        [FromBody, Required] TarefaRequest request)
        {
            var response = await _tarefaService.GravarDemandaAsync(request);

            if (response.Mensagem.Any())
            {
                return BadRequest(response);
            }

            response.CodRetorno = CodigoRetorno.Sucesso;
            return Ok(response);
        }
    }
}
