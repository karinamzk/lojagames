﻿using lojagames.Model;
using Microsoft.EntityFrameworkCore;

namespace lojagames.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");

            // Relacionamento Produtos - categoria

              _ = modelBuilder.Entity<Produto>()
                    .HasOne(_ => _.Categoria)
                    .WithMany(c => c.Produto)
                    .HasForeignKey("TemaId")
                    .OnDelete(DeleteBehavior.Cascade); 
        }

        // Registrar DbSet - Objeto responsável por manipular a Tabela
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;

    }
}
