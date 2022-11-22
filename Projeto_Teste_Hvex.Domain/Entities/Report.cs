using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class Report : EntityBase
    {
        public bool Status { get; set; }
        //RelationShips EFCORE
        public int TestId { get; set; }
        [JsonIgnore]
        public virtual Test Test { get; set; }
        public int TransformerId { get; set; }
        [JsonIgnore]
        public virtual Transformer Transformer { get; set; }

    }
}
