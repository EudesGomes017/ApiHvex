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
    public class TransformerService : ITransformerService
    {
        private readonly ITransformerRepo _transformerRepo;

        public TransformerService(ITransformerRepo transformerRepo)
        {
            _transformerRepo = transformerRepo;
        }

        public async Task<Transformer> AdicionarTransformerAsync(Transformer model)
        {

            if (await _transformerRepo.BuscarTransformerPorIdAsync(model.Id) != null)
                throw new Exception($"Já existe um Transformer cadastrado com o Id: {model.Id}");

            if (await _transformerRepo.BuscarTransformerPorIdAsync(model.Id) == null)
            {
                _transformerRepo.Adicionar(model);

                if (await _transformerRepo.SalvarMudancasAsync())
                {
                    return model;
                }
            }
            return null;
        }

        public async Task<Transformer> AtualizarTransformerAsync(Transformer model)
        {
            var transformer = await _transformerRepo.BuscarTransformerPorIdAsync(model.Id);

            if (transformer != null)
            {
                _transformerRepo.Atualizar(model);

                if (await _transformerRepo.SalvarMudancasAsync())
                {
                    return model;
                }
            }
            return null;
        }

        public async Task<Transformer> BuscarTransformerPorIdAsync(int? transformerId)
        {
            try
            {
                var transformer = await _transformerRepo.BuscarTransformerPorIdAsync(transformerId);
                if (transformer == null)
                    throw new Exception($"Não existe Transformer com o Id: {transformerId}.");

                return transformer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Transformer[]> BuscarTransformersAsync()
        {
            try
            {
                var transformers = await _transformerRepo.BuscarTransformersAsync();
                if (transformers == null) return null;

                return transformers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarTransformerPorIdAsync(int? transformerId)
        {
            var transformer = await _transformerRepo.BuscarTransformerPorIdAsync(transformerId);

            if (transformer == null) throw new Exception($"Transformer com Id: {transformerId} não existe");

            _transformerRepo.Deletar(transformer);

            if (await _transformerRepo.SalvarMudancasAsync())
            {
                return true;
            }
            return false;
        }
    }
}
