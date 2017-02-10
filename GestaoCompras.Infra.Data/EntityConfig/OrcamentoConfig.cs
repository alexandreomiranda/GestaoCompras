using GestaoCompras.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Infra.Data.EntityConfig
{
    public class OrcamentoConfig : EntityTypeConfiguration<Orcamento>
    {
        public OrcamentoConfig()
        {
            HasKey(c => c.OrcamentoId);
        }
    }
}
