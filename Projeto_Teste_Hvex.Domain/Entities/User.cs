using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class User : EntityBase
    {
        public string? Email { get; set; }
        public ICollection<Transformer>? Transformers { get; set; }
        public int? TransformerId { get; set; }
    }
}
