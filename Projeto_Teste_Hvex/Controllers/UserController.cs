using Microsoft.AspNetCore.Mvc;
using Projeto_Teste_Hvex.Domain.Entities;
using Projeto_Teste_Hvex.Domain.Interface.Services;

namespace Projeto_Teste_Hvex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.BuscarUsersAsync();
                if (users == null) return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar todos os Users. Erro: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await _userService.BuscarUserPorIdAsync(userId);

            try
            {
                if (user == null) return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar User: {user.Name}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            try
            {
                var user = await _userService.AdicionarUserAsync(model);

                if (user == null) return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar User. Erro: {ex.Message}");
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Put(int userId, User model)
        {
            try
            {
                if (userId != model.Id)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                        $"Você está tentando atualizar um User errado");
                }

                var user = await _userService.AtualizarUserAsync(model);
                if (user == null) return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o User: {model.Name}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var user = await _userService.BuscarUserPorIdAsync(userId);

            try
            {
                if (user == null)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                       $"Você está tentando deletar um User inexistente");
                }

                if (await _userService.DeletarUserPorIdAsync(userId))
                {
                    return Ok(new { message = $"O User: {user.Name} deletado com sucesso" });
                }
                else
                {
                    return BadRequest($"Ocorreu um erro não específico ao tentar deletar o User: {user.Name}");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o User: {user.Name}. Erro: {ex.Message}");
            }
        }
    }
}
