using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Domain.Entities
{
    public class Transformer : EntityBase
    {
        public int InternalNumber { get; set; }
        public string? TensionClass { get; set; }
        public int Potency { get; set; }
        //public User? User { get; set; }
        public int UserId { get; set; }
        public ICollection<Test>? Tests { get; set; }
        public int TestId { get; set; }
        //public Report? Report { get; set; }
        public int? ReportId { get; set; }
        public string? Current { get; set; }
    }
}
