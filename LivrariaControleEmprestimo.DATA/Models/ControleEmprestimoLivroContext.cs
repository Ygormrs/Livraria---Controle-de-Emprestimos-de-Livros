using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LivrariaControleEmprestimo.DATA.Models;

public partial class ControleEmprestimoLivroContext : DbContext
{
    public ControleEmprestimoLivroContext()
    {
    }

    public ControleEmprestimoLivroContext(DbContextOptions<ControleEmprestimoLivroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5VTI9UI\\SQLSERVER2022;Database=ControleEmprestimoLivro;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bairro");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cidade");
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Endereco)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.ToTable("Livro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Editora)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("editora");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
        {
            entity.ToTable("Livro_Cliente_Emprestimo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DataDevolucao)
                .HasColumnType("datetime")
                .HasColumnName("dataDevolucao");
            entity.Property(e => e.DataEmprestimo)
                .HasColumnType("datetime")
                .HasColumnName("dataEmprestimo");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdLivro).HasColumnName("idLivro");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.LivroClienteEmprestimos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Livro_Cliente_Emprestimo_Cliente");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.LivroClienteEmprestimos)
                .HasForeignKey(d => d.IdLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Livro_Cliente_Emprestimo_Livro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
