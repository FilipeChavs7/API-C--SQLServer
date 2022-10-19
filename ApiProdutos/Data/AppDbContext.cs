using Microsoft.EntityFrameworkCore;
using System;

namespace ApiProdutos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                    .HasMaxLength(60);

            modelBuilder.Entity<Departamento>()
                .Property(p => p.nome)
                    .HasMaxLength(60);

            modelBuilder.Entity<Funcionario>()
                .Property(p => p.nome)
                    .HasMaxLength(60);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                    .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .HasData(
                   new Produto { Id = 1, Nome = "Fichario", Preco = 10.75M, Estoque = 10 },
                   new Produto { Id = 2, Nome = "Bolsinha", Preco = 30.50M, Estoque = 8 },
                   new Produto { Id = 3, Nome = "Lapiseira", Preco = 100.00M, Estoque = 5 }
                   );

            modelBuilder.Entity<Departamento>()
                .HasData(
                   new Departamento { departamentoId = 1, nome = "TI", maximoFuncionarios = 10 },
                   new Departamento { departamentoId = 2, nome = "Suporte", maximoFuncionarios = 10 }
                   );

            modelBuilder.Entity<Funcionario>()
                .HasData(
                   new Funcionario { funcionarioId = 1, nome = "Filipe", departamento_id = 1, data_entrada = DateTime.Now },
                   new Funcionario { funcionarioId = 2, nome = "Fernando", departamento_id = 2, data_entrada = DateTime.Now }
                   );
        }
    }
}
