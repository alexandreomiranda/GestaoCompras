using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Domain.Entities
{
    public class SolicitacaoCompra
    {
        public int SolicitacaoCompraId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string DeptoSolicitante { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataLimiteRecebimento { get; set; }
        public string StatusSolicitacao { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
