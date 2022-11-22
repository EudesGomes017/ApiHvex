using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Name { get; set; }

        public EntityBase() => CreatedAt = DateTime.Now; // a data de criação é mesma da data atual
    }
}
