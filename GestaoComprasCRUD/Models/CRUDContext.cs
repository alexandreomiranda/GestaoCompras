namespace GestaoComprasCRUD.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CRUDContext : DbContext
    {
        public CRUDContext()
            : base("name=CRUDContext")
        {
        }

        public virtual DbSet<ClasseProduto> ClasseProduto { get; set; }
        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Orcamento> Orcamento { get; set; }
        public virtual DbSet<OrcamentoItem> OrcamentoItem { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<SolicitacaoCompra> SolicitacaoCompra { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClasseProduto>()
                .Property(e => e.NomeClasse)
                .IsUnicode(false);

            modelBuilder.Entity<ClasseProduto>()
                .HasMany(e => e.Produto)
                .WithRequired(e => e.ClasseProduto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Telefone3)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.NomeFornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.CNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.NomeFantasiaFornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(e => e.Contato)
                .WithRequired(e => e.Fornecedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(e => e.Endereco)
                .WithRequired(e => e.Fornecedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(e => e.Orcamento)
                .WithRequired(e => e.Fornecedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orcamento>()
                .Property(e => e.NumeroOrcamento)
                .IsUnicode(false);

            modelBuilder.Entity<Orcamento>()
                .HasMany(e => e.OrcamentoItem)
                .WithRequired(e => e.Orcamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.NomeProduto)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DescricaoProduto)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.OrcamentoItem)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.SolicitacaoCompra)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SolicitacaoCompra>()
                .Property(e => e.UsuarioSolicitante)
                .IsUnicode(false);

            modelBuilder.Entity<SolicitacaoCompra>()
                .Property(e => e.DeptoSolicitante)
                .IsUnicode(false);

            modelBuilder.Entity<SolicitacaoCompra>()
                .Property(e => e.StatusSolicitacao)
                .IsUnicode(false);

            modelBuilder.Entity<Unidade>()
                .Property(e => e.NomeUnidade)
                .IsUnicode(false);

            modelBuilder.Entity<Unidade>()
                .HasMany(e => e.Produto)
                .WithRequired(e => e.Unidade)
                .WillCascadeOnDelete(false);
        }
    }
}
