using Microsoft.AspNetCore.Mvc;
using Projeto_Teste_Hvex.Domain.Entities;
using Projeto_Teste_Hvex.Domain.Interface.Services;

namespace Projeto_Teste_Hvex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        //buscar por todos Ids
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tests = await _testService.BuscarTestsAsync();
                if (tests == null) return NoContent();

                return Ok(tests);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar todas os Tests. Erro: {ex.Message}");
            }
        }

        //Buscar po Id
        [HttpGet("{testId}")]
        public async Task<IActionResult> Get(int testId)
        {
            var test = await _testService.BuscarTestPorIdAsync(testId);

            try
            {
                if (test == null) return NoContent();

                return Ok(test);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar Test: {test.Name}. Erro: {ex.Message}");
            }
        }
            
        [HttpPost]
        public async Task<IActionResult> Post(Test model)
        {
            try
            {
                var test = await _testService.AdicionarTestAsync(model);

                if (test == null) return NoContent();

                return Ok(test);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Test. Erro: {ex.Message}");
            }
        }

        [HttpPut("{testId}")]
        public async Task<IActionResult> Put(int testId, Test model)
        {
            try
            {
                if (testId != model.Id)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                        $"Você está tentando atualizar o Test errado");
                }

                var test = await _testService.AtualizarTestAsync(model);
                if (test == null) return NoContent();

                return Ok(test);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o Test: {model.Name}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{testId}")]
        public async Task<IActionResult> Delete(int testId)
        {
            var test = await _testService.BuscarTestPorIdAsync(testId);

            try
            {
                if (test == null)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                       $"Você está tentando deletar um Test inexistente");
                }

                if (await _testService.DeletarTestPorIdAsync(testId))
                {
                    return Ok(new { message = $"O Test: {test.Name} deletado com sucesso" });
                }
                else
                {
                    return BadRequest($"Ocorreu um erro não específico ao tentar deletar o Test: {test.Name}");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o Test: {test.Name}. Erro: {ex.Message}");
            }
        }
    }
}
