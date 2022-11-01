using Projeto_Teste_Hvex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Interface.Services
{
    public interface IReportService
    {
        Task<Report> AdicionarReportAsync(Report report);
        Task<Report> AtualizarReportAsync(Report report);
        Task<Report> BuscarReportPorIdAsync(int? reportId);
        Task<Report[]> BuscarReportsAsync();
        Task<bool> DeletarReportPorIdAsync(int? reportId);
    }
}
