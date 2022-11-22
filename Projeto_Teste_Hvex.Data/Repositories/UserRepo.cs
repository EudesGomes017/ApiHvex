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
    public class UserRepo : GeralRepo, IUserRepo
    {
        private readonly DataContext _context;
        public UserRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> BuscarUserPorIdAsync(int? userId)
        {
            IQueryable<User> query = _context.User;

            query = query.AsNoTracking()
                         .Where(x => x.Id == userId)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> BuscarUserPorEmailAsync(string email)
        {
            IQueryable<User> query = _context.User;

            query = query.AsNoTracking()
                         .Where(x => x.Email == email)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User[]> BuscarUsersAsync()
        {
            IQueryable<User> query = _context.User;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
    }
}
