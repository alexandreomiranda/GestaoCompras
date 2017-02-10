using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoCompras.Domain.Entities
{
    public class Orcamento
    {
        public int OrcamentoId { get; set; }
        public string NumeroOrcamento { get; set; }
        public DateTime DataOrcamento { get; set; }
        public DateTime DataValidadeOrcamento { get; set; }
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<OrcamentoItem> OrcamentoItens { get; set; }
    }
}