namespace GestaoComprasCRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orcamento")]
    public partial class Orcamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orcamento()
        {
            OrcamentoItem = new HashSet<OrcamentoItem>();
        }

        public int OrcamentoId { get; set; }

        [StringLength(100)]
        public string NumeroOrcamento { get; set; }

        public DateTime DataOrcamento { get; set; }

        public DateTime DataValidadeOrcamento { get; set; }

        public int FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrcamentoItem> OrcamentoItem { get; set; }
    }
}
