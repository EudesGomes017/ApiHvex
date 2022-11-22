using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class Transformer : EntityBase
    {
        public int InternalNumber { get; set; }
        public string TensionClass { get; set; }
        public int Potency { get; set; }
        public string Current { get; set; }
        //relationShips EFCORE
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> Reports { get; set; }
        [JsonIgnore]
        public virtual ICollection<Test> Tests { get; set; }

    }
}
