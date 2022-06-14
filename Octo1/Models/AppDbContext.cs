using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Octo1.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbEndereco> TbEndereco { get; set; }
        public virtual DbSet<TbTelefone> TbTelefone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=GUSTAVOPC\\SQLEXPRESS;Initial Catalog=dbDistribuidora;User ID=sa;Password=@123ASD");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__tbClient__40F9A207941F04D7");

                entity.ToTable("tbCliente");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.CpfCnpj)
                    .IsRequired()
                    .HasColumnName("cpf_cnpj")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("data_cadastro")
                    .HasColumnType("date");

                entity.Property(e => e.DataNascFund)
                    .HasColumnName("data_nasc_fund")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.RgIe)
                    .IsRequired()
                    .HasColumnName("rg_ie")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<TbEndereco>(entity =>
            {
                entity.HasKey(e => new { e.Codigo, e.CodPessoa })
                    .HasName("PK__tbEndere__87386D9FE168031C");

                entity.ToTable("tbEndereco");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithMany(p => p.TbEndereco)
                    .HasForeignKey(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbEnderec__codPe__286302EC");
            });

            modelBuilder.Entity<TbTelefone>(entity =>
            {
                entity.HasKey(e => new { e.Codigo, e.CodPessoa })
                    .HasName("PK__tbTelefo__87386D9F6694D231");

                entity.ToTable("tbTelefone");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");

                entity.Property(e => e.Ddd)
                    .IsRequired()
                    .HasColumnName("ddd")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Observacoes)
                    .HasColumnName("observacoes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithMany(p => p.TbTelefone)
                    .HasForeignKey(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbTelefon__codPe__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
