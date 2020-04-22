using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Enity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EnitiyConfig
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {

            //Fluent API
            builder
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Contatos)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(e => e.Telefone)
                .HasColumnType("varchar(15)");

        }
    }
}
