using Projeto_Teste_Hvex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Interface.Services
{
    public interface ITestService
    {
        Task<Test> AdicionarTestAsync(Test test);
        Task<Test> AtualizarTestAsync(Test test);
        Task<Test> BuscarTestPorIdAsync(int? testId);
        Task<Test[]> BuscarTestsAsync();
        Task<bool> DeletarTestPorIdAsync(int? testId);
    }
}
