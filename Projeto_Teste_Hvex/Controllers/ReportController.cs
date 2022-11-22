using Microsoft.AspNetCore.Mvc;
using Projeto_Teste_Hvex.Domain.Entities;
using Projeto_Teste_Hvex.Domain.Interface.Services;

namespace Projeto_Teste_Hvex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        //injeção de dependencia 
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

         

        [HttpGet("{reportId}")]
        public async Task<IActionResult> Get(int reportId)
        {
            var report = await _reportService.BuscarReportPorIdAsync(reportId);

            try
            {
                if (report == null) return NoContent();

                return Ok(report);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar report: {report.Name}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Report model)
        {
            try
            {
                var report = await _reportService.AdicionarReportAsync(model);

                if (report == null) return NoContent();

                return Ok(report);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Report. Erro: {ex.Message}");
            }
        }

        [HttpPut("{reportId}")]
        public async Task<IActionResult> Put(int reportId, Report model)
        {
            try
            {
                if (reportId != model.Id)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                        $"Você está tentando atualizar o Report errado");
                }

                var report = await _reportService.AtualizarReportAsync(model);
                if (report == null) return NoContent();

                return Ok(report);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o Report: {model.Name}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{reportId}")]
        public async Task<IActionResult> Delete(int reportId)
        {
            var report = await _reportService.BuscarReportPorIdAsync(reportId);

            try
            {
                if (report == null)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                       $"Você está tentando deletar um Report inexistente");
                }

                if (await _reportService.DeletarReportPorIdAsync(reportId))
                {
                    return Ok(new { message = $"O Report: {report.Name} deletado com sucesso" });
                }
                else
                {
                    return BadRequest($"Ocorreu um erro não específico ao tentar deletar o Report: {report.Name}");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o Report: {report.Name}. Erro: {ex.Message}");
            }
        }
    }
}
