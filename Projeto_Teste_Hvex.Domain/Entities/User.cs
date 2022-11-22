using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transformer> Transformers { get; set; }

    }
}
