using Jobfy_API.Models;
using Jobfy_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jobfy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentoController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpPost("cadastrar-agendamento")]
        public async Task<IActionResult> CadastroAgendamento([FromBody] Agendamento agendamento)
        {
            var criarAgendamento = await _agendamentoService.CadastrarAgendamento(agendamento);

            if (criarAgendamento is null)
                return BadRequest();
       
            return Ok();
        }

        [HttpGet("get-agendamentos")]
        public async Task<IActionResult> GetTodosAgendamentos()
        {
            var agendamentos = await _agendamentoService.GetTodosAgendamentos();
            return Ok(agendamentos);
        }

        [HttpPut("editar-agendamento")]
        public async Task<IActionResult> EdicaoAgendamento([FromBody] Agendamento agendamento)
        {
            var edicaoAgendamento = await _agendamentoService.EditarAgendamento(agendamento);

            if (edicaoAgendamento is null)
                return BadRequest();

            return Ok(edicaoAgendamento);
        }

        [HttpPost("aplicar-decisao")]
        public async Task<IActionResult> AplicarDecisaoAgendamento([FromBody] AtualizacaoDecisaoRequest request)
        {
            var retornoDecisao = await _agendamentoService.AplicarDecisaoAgendamento(request.Id, request.Decisao);

            if(!retornoDecisao.Sucesso)
                return BadRequest(retornoDecisao.Mensagem);

            return Ok(retornoDecisao.Mensagem);
        }
    }

    public class AtualizacaoDecisaoRequest
    {
        public int Id { get; set; }
        public string Decisao { get; set; }
    }
}
