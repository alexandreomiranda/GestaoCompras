using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GestaoCompras.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using GestaoCompras.Infra.Data.EntityConfig;

namespace GestaoCompras.Infra.Data.Context
{
    public class GestaoComprasContext : DbContext
    {
        public GestaoComprasContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<OrcamentoItem> OrcamentosItens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ClasseProduto> ClasseProdutos { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<SolicitacaoCompra> SolicitacaoCompras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClasseProdutoConfig());
            modelBuilder.Configurations.Add(new ContatoConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new OrcamentoConfig());
            modelBuilder.Configurations.Add(new OrcamentoItemConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new UnidadeConfig());
            modelBuilder.Configurations.Add(new SolicitacaoCompraConfig());

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
