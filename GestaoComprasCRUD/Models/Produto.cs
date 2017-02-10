namespace GestaoComprasCRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produto")]
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            OrcamentoItem = new HashSet<OrcamentoItem>();
            SolicitacaoCompra = new HashSet<SolicitacaoCompra>();
        }

        public int ProdutoId { get; set; }

        [StringLength(100)]
        public string NomeProduto { get; set; }

        [StringLength(100)]
        public string DescricaoProduto { get; set; }

        public int ClasseProdutoId { get; set; }

        public int UnidadeId { get; set; }

        public virtual ClasseProduto ClasseProduto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrcamentoItem> OrcamentoItem { get; set; }

        public virtual Unidade Unidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitacaoCompra> SolicitacaoCompra { get; set; }
    }
}
