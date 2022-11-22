using Microsoft.AspNetCore.Mvc;
using Projeto_Teste_Hvex.Domain.Entities;
using Projeto_Teste_Hvex.Domain.Interface.Services;

namespace Projeto_Teste_Hvex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransformerController : ControllerBase
    {
        //injeção de dependencia
        private readonly ITransformerService _transformerService;

        //contrutor
        public TransformerController(ITransformerService transformerService)
        {
            _transformerService = transformerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var transformers = await _transformerService.BuscarTransformersAsync();
                if (transformers == null) return NoContent();

                return Ok(transformers);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar todos os Transformers. Erro: {ex.Message}");
            }
        }

        [HttpGet("{transformerId}")]
        public async Task<IActionResult> Get(int transformerId)
        {
            var transformer = await _transformerService.BuscarTransformerPorIdAsync(transformerId);

            try
            {
                if (transformer == null) return NoContent();

                return Ok(transformer);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar Transformer: {transformer.Name}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Transformer model)
        {
            try
            {
                var transformer = await _transformerService.AdicionarTransformerAsync(model);

                if (transformer == null) return NoContent();

                return Ok(transformer);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Transformer. Erro: {ex.Message}");
            }
        }

        [HttpPut("{transformerId}")]
        public async Task<IActionResult> Put(int transformerId, Transformer model)
        {
            try
            {
                if (transformerId != model.Id)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                        $"Você está tentando atualizar o Transformer errado");
                }

                var transformer = await _transformerService.AtualizarTransformerAsync(model);
                if (transformer == null) return NoContent();

                return Ok(transformer);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o Transformer: {model.Name}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{transformerId}")]
        public async Task<IActionResult> Delete(int transformerId)
        {
            var transformer = await _transformerService.BuscarTransformerPorIdAsync(transformerId);

            try
            {
                if (transformer == null)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                       $"Você está tentando deletar um Transformer inexistente");
                }

                if (await _transformerService.DeletarTransformerPorIdAsync(transformerId))
                {
                    return this.StatusCode(StatusCodes.Status203NonAuthoritative,
                       $"O Transformer: {transformer.Name} deletado com sucesso");
                    //return Ok(new { message = $"O Transformer: {transformer.Name} deletado com sucesso" });
                }
                else
                {
                    return BadRequest($"Ocorreu um erro não específico ao tentar deletar o Transformer: {transformer.Name}");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o Transformer: {transformer.Name}. Erro: {ex.Message}");
            }
        }
    }
}
