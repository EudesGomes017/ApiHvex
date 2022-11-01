using Projeto_Teste_Hvex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Interface.Services
{
    public interface ITransformerService
    {
        Task<Transformer> AdicionarTransformerAsync(Transformer transformer);
        Task<Transformer> AtualizarTransformerAsync(Transformer transformer);
        Task<Transformer[]> BuscarTransformersAsync();
        Task<Transformer> BuscarTransformerPorIdAsync(int? transformerId);
        Task<bool> DeletarTransformerPorIdAsync(int? transformerId);
    }
}
