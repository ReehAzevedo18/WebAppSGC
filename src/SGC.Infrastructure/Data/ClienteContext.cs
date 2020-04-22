using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Enity;
using SGC.Infrastructure.EnitiyConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.Data
{
    public class ClienteContext : DbContext //herdar a classe
    {
        /*passar o contexto qual a classe ta usando*/
        public ClienteContext(DbContextOptions<ClienteContext> options)  : base(options) //classe base é o DBContext
        {

        }

        //Criando uma tabela no banco de forma manual
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        //Configuração do EnityFramework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente"); //informando ao EF como será a nomenclatura da tabela
            modelBuilder.Entity<Contato>().ToTable("Contato");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Profissao>().ToTable("Profissao");
            modelBuilder.Entity<ProfissaoCliente>().ToTable("ProfissaoCliente");

            //Configuração para o EntityConfig
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new ProfissaoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ProfissaoClienteMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
        }
    }
}
