using GestaoCompras.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Domain.Interfaces.Repository
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Fornecedor ObterPorCnpj(string cnpj);
        IEnumerable<Fornecedor> ObterFornecedorPorProduto(int produtoId);
    }
}
