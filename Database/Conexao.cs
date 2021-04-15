using Microsoft.EntityFrameworkCore;
using ParcialAncelmo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcialAncelmo.Database
{
    public class Conexao : DbContext
    {
        public Conexao(DbContextOptions<Conexao> options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conteudo> Conteudos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoConteudo> TipoConteudos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .Property(p => p.linkedin)
                .HasMaxLength(255);

            modelBuilder.Entity<Autor>()
                .Property(p => p.nome)
                .HasMaxLength(255);

            modelBuilder.Entity<Cliente>()
                .Property(p => p.nome)
                .HasMaxLength(255);


            modelBuilder.Entity<Cliente>()
                .Property(p => p.email)
                .HasMaxLength(255);

            modelBuilder.Entity<Cliente>()
                .Property(p => p.endereco)
                .HasMaxLength(500);

            modelBuilder.Entity<Cliente>()
                .Property(p => p.sexo)
                .HasMaxLength(255);

            modelBuilder.Entity<Cliente>()
                .Property(p => p.telefone)
                .HasMaxLength(255);

            modelBuilder.Entity<Conteudo>()
                .Property(p => p.texto)
                .HasMaxLength(10000);

            modelBuilder.Entity<Conteudo>()
                .Property(p => p.link)
                .HasMaxLength(500);


            modelBuilder.Entity<Conteudo>()
                .Property(p => p.dataDeCadastro)
                .ValueGeneratedOnAdd();

            
            modelBuilder.Entity<Produto>()
                .Property(p => p.tipo)
                .HasMaxLength(500);

            modelBuilder.Entity<Produto>()
                .Property(p => p.tipo)
                .HasMaxLength(500);


            modelBuilder.Entity<TipoConteudo>()
                .Property(p => p.descricao)
                .HasMaxLength(500);

            modelBuilder.Entity<Autor>()
                .HasData(
                new Autor { id = 1, nome = "Josefina da Silva", linkedin = "www.linkedin.com/in/josefina-silva/" });

            modelBuilder.Entity<Cliente>()
                .HasData(
                new Cliente { id = 1, nome = "Juscelino Peres", dataDeNascimento = DateTime.Now, email = "teste123@gmail.com", endereco = "Avenida Rafael Vaz e Silva, 1111, Liberdade, Porto Velho, Rondônia", sexo = "Masculino", telefone = "69 9999999999" });

            modelBuilder.Entity<Conteudo>()
                .HasData(
                new Conteudo { id = 1, dataDeCadastro = DateTime.Now, link = "siojaoisjaoijsiojoia", texto = "sokaoskoaksok" });

            modelBuilder.Entity<Produto>()
                .HasData(
                new Produto { id = 1, descricao = "nsiasiuhauhs", valor = 100.0 });

            modelBuilder.Entity<TipoConteudo>()
                .HasData(
                new TipoConteudo { id = 1, descricao = "isjaoijsoiaj" });

        }
    }
}
