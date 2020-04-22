using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Enity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EnitiyConfig
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .Property(end => end.CEP)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder
                .Property(end => end.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(end => end.Referencia)
                .HasColumnType("varchar(1000)");
        }
    }
}
