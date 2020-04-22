using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Enity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EnitiyConfig
{
    public class ProfissaoClienteMap : IEntityTypeConfiguration<ProfissaoCliente>
    {
        public void Configure(EntityTypeBuilder<ProfissaoCliente> builder)
        {
            builder
             .HasKey(c => c.Id);

            builder
                 .HasOne(pC => pC.Cliente)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder
                .HasOne(pC => pC.Profissao)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ProfissaoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
