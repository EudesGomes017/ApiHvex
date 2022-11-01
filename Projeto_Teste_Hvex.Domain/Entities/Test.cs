using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class Test : EntityBase
    {
        public int DurationInSeconds { get; set; }
        public bool Status { get; set; }
        //public Transformer? Transformer { get; set; }
        public int? TransformerId { get; set; }
        //public Report? Report { get; set; }
        public int? ReportId { get; set; }
    }
}
