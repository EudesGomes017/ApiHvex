using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Interface.Repositories
{
    public interface IGeralRepo
    {
        /*como estou utilizando um generico, exemplo adiciona um Test oq chegar é generico ele vai adcionar
         */
        void Adicionar<T>(T entity) where T : class; //desde q ele seja do tipo class
        void Atualizar<T>(T entity) where T : class;
        void Deletar<T>(T entity) where T : class;
        void DeletarVarias<T>(T[] entityArray) where T : class;
        Task<bool> SalvarMudancasAsync();
    }
}
