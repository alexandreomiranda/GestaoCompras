namespace GestaoComprasCRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fornecedor")]
    public partial class Fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fornecedor()
        {
            Contato = new HashSet<Contato>();
            Endereco = new HashSet<Endereco>();
            Orcamento = new HashSet<Orcamento>();
        }

        public int FornecedorId { get; set; }

        [StringLength(100)]
        public string NomeFornecedor { get; set; }

        [StringLength(100)]
        public string CNPJ { get; set; }

        public bool Ativo { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(100)]
        public string NomeFantasiaFornecedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contato> Contato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Endereco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orcamento> Orcamento { get; set; }
    }
}
