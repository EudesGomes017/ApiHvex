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
    public class TestRepo : GeralRepo, ITestRepo
    {
        private readonly DataContext _context;
        public TestRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Test> BuscarTestPorIdAsync(int? testId)
        {
            IQueryable<Test> query = _context.Test;

            query = query.AsNoTracking()
                         .Where(x => x.Id == testId)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Test[]> BuscarTestsAsync()
        {
            IQueryable<Test> query = _context.Test;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
    }
}
