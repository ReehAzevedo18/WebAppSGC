using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Enity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EnitiyConfig
{
    public class ProfissaoMap : IEntityTypeConfiguration<Profissao>
    {

        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder
                .HasKey(p => p.ProfissaoId);

            builder
                .Property(p => p.Nome)
                .HasColumnType("varchar(400)")
                .IsRequired();

            builder
                .Property(p => p.CBO)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder
                .Property(p => p.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

        }
    }
}
