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
    public class TransformerRepo : GeralRepo, ITransformerRepo
    {
        private readonly DataContext _context;
        public TransformerRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Transformer> BuscarTransformerPorIdAsync(int? transformerId)
        {
            IQueryable<Transformer> query = _context.Transformer;

            query = query.AsNoTracking()
                         .Where(x => x.Id == transformerId)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Transformer[]> BuscarTransformersAsync()
        {
            IQueryable<Transformer> query = _context.Transformer;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
    }
}
