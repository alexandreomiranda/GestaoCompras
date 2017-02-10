namespace GestaoComprasCRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SolicitacaoCompra")]
    public partial class SolicitacaoCompra
    {
        public int SolicitacaoCompraId { get; set; }

        public DateTime DataSolicitacao { get; set; }

        [StringLength(100)]
        public string UsuarioSolicitante { get; set; }

        [StringLength(100)]
        public string DeptoSolicitante { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataLimiteRecebimento { get; set; }

        [StringLength(100)]
        public string StatusSolicitacao { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
