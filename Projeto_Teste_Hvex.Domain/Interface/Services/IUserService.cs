using Projeto_Teste_Hvex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Interface.Services
{
    public interface IUserService
    {
        Task<User> AdicionarUserAsync(User user);
        Task<User> AtualizarUserAsync(User user);
        Task<User> BuscarUserPorIdAsync(int? userId);
        Task<User[]> BuscarUsersAsync();
        Task<bool> DeletarUserPorIdAsync(int? userId);
    }
}
