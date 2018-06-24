using System;
using System.ComponentModel.DataAnnotations;
using eLibrary1.Models;
using Microsoft.EntityFrameworkCore;

namespace eLibrary1.Models
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=banconovo.db");
        }
    }
}