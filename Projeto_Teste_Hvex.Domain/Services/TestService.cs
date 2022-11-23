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
    public class TestService : ITestService
    {
        private readonly ITestRepo _testRepo;

        public TestService(ITestRepo testRepo)
        {
            _testRepo = testRepo;
        }
        public async Task<Test> AdicionarTestAsync(Test model)
        {
            {

                if (await _testRepo.BuscarTestPorIdAsync(model.Id) != null)
                    throw new Exception($"Já existe um Test cadastrado com o Id: {model.Id}");

                if (await _testRepo.BuscarTestPorIdAsync(model.Id) == null)
                {
                    //esse Adicionar é do  IGeralRepo, pq o geral ele só adicionar
                    _testRepo.Adicionar(model);

                    if (await _testRepo.SalvarMudancasAsync())
                    {
                        return model;
                    }
                }
                return null;
            }
        }

        /*quando atualizamos estamos mandando o Id no model que sta chegando  Ele tem que fazer a Busca 
         do teste por Id */
        public async Task<Test> AtualizarTestAsync(Test model)
        {
            var test = await _testRepo.BuscarTestPorIdAsync(model.Id);

            ///o model é o cara novo com as informações nova que quero atualizar no nosso test(que esta no nosso banco)
            //ele é diferente de null, então pegue o repositorio atualizar e passa o model que estou passando
            if (test != null)
            {
                _testRepo.Atualizar(model);

                if (await _testRepo.SalvarMudancasAsync())
                {
                    return model;
                }
            }
            return null;
        }

        public async Task<Test> BuscarTestPorIdAsync(int? testId)
        {
            try
            {
                var test = await _testRepo.BuscarTestPorIdAsync(testId);
                if (test == null)
                    throw new Exception($"Não existe Test com o Id: {testId}.");

                return test;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Test[]> BuscarTestsAsync()
        {
            try
            {
                var tests = await _testRepo.BuscarTestsAsync();
                if (tests == null) return null;

                return tests;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarTestPorIdAsync(int? testId)
        {
            var test = await _testRepo.BuscarTestPorIdAsync(testId);

            if (test == null) throw new Exception($"Test com Id: {testId} não existe");

            _testRepo.Deletar(test);

            if (await _testRepo.SalvarMudancasAsync())
            {
                return true;
            }
            return false;
        }
    }
}
