using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Enity;
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



        //Criando uma tabela no banco
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

            #region Configurações de cliente

            //Explicitando informações com Fluent API
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId); //hasKey dizendo que é chave primária

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Contatos) //HasMany dizendo que é tem muitos contatos
                .WithOne(c => c.Cliente)  //WithOne dizendo que é tem muitos contatos para um unico cliente
                .HasForeignKey(c => c.ClienteId) //HasForeignKey dizendo qual a chave estrangeira na tabela cliente
                .HasPrincipalKey(c => c.ClienteId);

            //Alterando os tipos das colunas das tabelas
            modelBuilder.Entity<Cliente>().Property(e => e.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            modelBuilder.Entity<Cliente>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();
            #endregion

            #region Configurações de Contato

            //Fluent API
            modelBuilder.Entity<Contato>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Contatos)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);

            modelBuilder.Entity<Contato>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Telefone)
                .HasColumnType("varchar(15)");
            #endregion

            #region Configurações de Profissão
            modelBuilder.Entity<Profissao>()
                .HasKey(p => p.ProfissaoId);

            modelBuilder.Entity<Profissao>().Property(p => p.Nome)
                    .HasColumnType("varchar(400)")
                    .IsRequired();

                modelBuilder.Entity<Profissao>().Property(p => p.CBO)
                    .HasColumnType("varchar(11)")
                    .IsRequired();

                modelBuilder.Entity<Profissao>().Property(p => p.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();
            #endregion

            #region Configurações de Endereço
                 modelBuilder.Entity<Endereco>().Property(end => end.CEP)
                   .HasColumnType("varchar(15)")
                   .IsRequired();

                modelBuilder.Entity<Endereco>().Property(end => end.Logradouro)
                  .HasColumnType("varchar(200)")
                  .IsRequired();

            modelBuilder.Entity<Endereco>().Property(end => end.Referencia)
             .HasColumnType("varchar(1000)");

            #endregion

            #region Configurações de Profissao Cliente
            modelBuilder.Entity<ProfissaoCliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(pC => pC.Cliente)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ClienteId);

            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(pC => pC.Profissao)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ProfissaoId);
            #endregion

            #region Configurações de Menu
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.SubMenu)
                .WithOne() //o submenu tem apenas um unico menu
                .HasForeignKey(x => x.MenuId);

                
            #endregion
        }
    }
}
