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
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        //user é objeto que estamos adicianando ele vai ter tudas as propriedades
        public async Task<User> AdicionarUserAsync(User user)
        {
            //pelo Email que estamos enviado ele busca o usuario, ele vai fazer a buscar e vai verificar se ja existe
            if (await _userRepo.BuscarUserPorEmailAsync(user.Email) != null)
                throw new Exception($"Já existe um User cadastrado com o Email: {user.Email}");

                _userRepo.Adicionar(user);

                if (await _userRepo.SalvarMudancasAsync())
                {
                    return user;
                }
            
            return null;
        }

        public async Task<User> AtualizarUserAsync(User model)
        {
            var user = await _userRepo.BuscarUserPorIdAsync(model.Id);

            if (user != null)
            {
                _userRepo.Atualizar(model);

                if (await _userRepo.SalvarMudancasAsync())
                {
                    return model;
                }
            }
            return null;
        }

        public async Task<User> BuscarUserPorIdAsync(int? userId)
        {
            try
            {
                var user = await _userRepo.BuscarUserPorIdAsync(userId);
                if (user == null)
                    throw new Exception($"Não existe Usuário com o Id: {userId}.");

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            
            }
        }

        public async Task<User> BuscarUserPorEmailAsync(string email)
        {
            try
            {
                var user = await _userRepo.BuscarUserPorEmailAsync(email);
                if (user == null)
                    throw new Exception($"Não existe Usuário com o Email: {email}.");

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User[]> BuscarUsersAsync()
        {
            try
            {
                var users = await _userRepo.BuscarUsersAsync();
                if (users == null) return null;

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarUserPorIdAsync(int? userId)
        {
            var user = await _userRepo.BuscarUserPorIdAsync(userId);

            if (user == null) throw new Exception($"User com Id: {userId} não existe");

            _userRepo.Deletar(user);

            if (await _userRepo.SalvarMudancasAsync())
            {
                return true;
            }
            return false;
        }
    }
}
