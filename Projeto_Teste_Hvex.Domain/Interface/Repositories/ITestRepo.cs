using Projeto_Teste_Hvex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Interface.Repositories
{
    public interface ITestRepo : IGeralRepo
    {
        Task<Test> BuscarTestPorIdAsync(int? testId);
        Task<Test[]> BuscarTestsAsync();
    }
}
