using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoCompras.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int ClasseProdutoId { get; set; }
        public virtual ClasseProduto ClasseProduto { get; set; }
        public int UnidadeId { get; set; }
        public virtual Unidade Unidade { get; set; }
        //public virtual ICollection<Fornecedor> Fornecedores { get; set; }
        public string NomeDescricao 
        {
            get
            {
                return NomeProduto + " " + DescricaoProduto;
            }
        }
    }
}