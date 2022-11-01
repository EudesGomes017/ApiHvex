using Projeto_Teste_Hvex.Domain.Entities;
using Projeto_Teste_Hvex.Domain.Interface.Repositories;
using Projeto_Teste_Hvex.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepo _reportRepo;

        public ReportService(IReportRepo reportRepo)
        {
            _reportRepo = reportRepo;
        }

        public async Task<Report> AdicionarReportAsync(Report report)
        {

            if (await _reportRepo.BuscarReportPorIdAsync(report.Id) != null)
                throw new Exception($"Já existe um Report cadastrado com o Id: {report.Id}");

            if (await _reportRepo.BuscarReportPorIdAsync(report.Id) == null)
            {
                _reportRepo.Adicionar(report);

                if (await _reportRepo.SalvarMudancasAsync())
                {
                    return report;
                }
            }
            return null;
        }

        public async Task<Report> AtualizarReportAsync(Report model)
        {
            var report = await _reportRepo.BuscarReportPorIdAsync(model.Id);

            if (report != null)
            {
                _reportRepo.Atualizar(model);

                if (await _reportRepo.SalvarMudancasAsync())
                {
                    return model;
                }
            }
            return null;
        }

        public async Task<Report> BuscarReportPorIdAsync(int? reportId)
        {
            try
            {
                var report = await _reportRepo.BuscarReportPorIdAsync(reportId);
                if (report == null)
                    throw new Exception($"Não existe Report com o Id: {reportId}.");

                return report;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Report[]> BuscarReportsAsync()
        {
            try
            {
                var reports = await _reportRepo.BuscarReportsAsync();
                if (reports == null) return null;

                return reports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarReportPorIdAsync(int? reportId)
        {
            var report = await _reportRepo.BuscarReportPorIdAsync(reportId);

            if (report == null) throw new Exception($"Report com Id: {reportId} não existe");

            _reportRepo.Deletar(report);

            if (await _reportRepo.SalvarMudancasAsync())
            {
                return true;
            }
            return false;
        }
    }
}
