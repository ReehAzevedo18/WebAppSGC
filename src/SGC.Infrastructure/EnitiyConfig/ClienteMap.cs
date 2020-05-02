using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Enity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EnitiyConfig
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //Explicitando informações com Fluent API
            builder
                .HasKey(c => c.ClienteId); //hasKey dizendo que é chave primária

            //Muitos para um
            builder
                .HasMany(c => c.Contatos) //HasMany dizendo que é tem muitos contatos
                .WithOne(c => c.Cliente)  //WithOne dizendo que é tem muitos contatos para um unico cliente
                .HasForeignKey(c => c.ClienteId) //HasForeignKey dizendo qual a chave estrangeira na tabela cliente
                .HasPrincipalKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); //não realizará o delete em cascata dos dados que estão na chave estrangeira



            //Um para um
            builder
                .HasOne(x => x.Endereco)
                .WithOne(x => x.Cliente)
                .HasForeignKey<Endereco>(x => x.ClienteId);

            //Alterando os tipos das colunas das tabelas
            builder.Property(e => e.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}
