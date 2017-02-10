using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Application.ViewModels
{
    public class SolicitacaoCompraViewModel
    {
        public int SolicitacaoCompraId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataSolicitacao { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string DeptoSolicitante { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataLimiteRecebimento { get; set; }
        public string StatusSolicitacao { get; set; }
        public int ProdutoId { get; set; }
    }
}
