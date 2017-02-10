using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoCompras.Domain.Entities
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string NomeFornecedor { get; set; }
        public string NomeFantasiaFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string Website { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}