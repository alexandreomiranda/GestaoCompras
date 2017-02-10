using System.Data.Entity.ModelConfiguration;
using GestaoCompras.Domain.Entities;

namespace GestaoCompras.Infra.Data.EntityConfig
{
    public class UnidadeConfig : EntityTypeConfiguration<Unidade>
    {
        public UnidadeConfig()
        {
            HasKey(c => c.UnidadeId);
        }
    }
}
