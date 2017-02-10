using GestaoCompras.Domain.Entities;
using GestaoCompras.Domain.Interfaces.Repository;
using GestaoCompras.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(GestaoComprasContext context)
            : base(context)
        {

        }


        public Fornecedor ObterPorCnpj(string cnpj)
        {
            return Buscar(c => c.CNPJ == cnpj).FirstOrDefault();
        }

        public IEnumerable<Fornecedor> ObterFornecedorPorProduto(int produtoId)
        {
            string sqlQuery = @"select * from Posts_Categories where PostId =@produtoId";
            return Db.Database.SqlQuery<Fornecedor>(sqlQuery, produtoId).ToList();
        }
    }
}
