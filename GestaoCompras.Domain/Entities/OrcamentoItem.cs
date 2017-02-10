using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoCompras.Domain.Entities
{
    public class OrcamentoItem
    {
        public int OrcamentoItemId { get; set; }
        public int OrcamentoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public virtual Orcamento Orcamento { get; set; }
        public virtual Produto Produto { get; set; }
    }
}