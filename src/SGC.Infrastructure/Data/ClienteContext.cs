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

        //Configuração do EnityFramework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Tb_cliente"); //informando ao EF como será a nomenclatura da tabela
        }
    }
}
