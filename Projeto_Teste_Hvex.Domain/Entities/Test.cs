using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class Test : EntityBase
    {
        public int DurationInSeconds { get; set; }
        public bool Status { get; set; }
        //RelationShips EFCORE
        public int TransformerId { get; set; }
        [JsonIgnore]
        public virtual Transformer Transformer { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> Reports { get; set; }

    }
}
