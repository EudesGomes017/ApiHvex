using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class Report : EntityBase
    {
        public bool Status { get; set; }
        //public Transformer? Transformer { get; set; }
        public int? TransformerId { get; set; }
        //public Test? Test { get; set; }
        public int? TestId { get; set; }
    }
}
