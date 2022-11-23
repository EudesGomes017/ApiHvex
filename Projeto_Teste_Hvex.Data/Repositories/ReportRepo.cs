using Microsoft.EntityFrameworkCore;
using Projeto_Teste_Hvex.Data.Context;
using Projeto_Teste_Hvex.Domain.Entities;
using Projeto_Teste_Hvex.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Data.Repositories
{
    public class ReportRepo : GeralRepo, IReportRepo
    {
        private readonly DataContext _context;
        public ReportRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Report> BuscarReportPorIdAsync(int? reportId)
        {
            IQueryable<Report> query = _context.Report;

            query = query.AsNoTracking()
                         .Where(x => x.Id == reportId)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Report[]> BuscarReportsAsync()
        {
            IQueryable<Report> query = _context.Report;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
    }
}
