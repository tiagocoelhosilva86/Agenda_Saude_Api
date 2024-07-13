using AgendaSaude.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Infra.Data.EntitiesConfiguration
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(x => x.IdAgenda);
            builder.Property(x => x.IdUsuario).IsRequired();
            builder.Property(x => x.IdPagamento);
            builder.Property(x => x.Descricao).HasMaxLength(250);
            builder.Property(x => x.DataAgendamendo).IsRequired();
            builder.Property(x => x.ConfirmacaoAgendamento);
            builder.Property(x => x.TipoPagamento);
            builder.Property(x => x.ValorConsulta);

            builder.HasOne(x => x.Usuario).WithMany(x => x.Agendamento)
                .HasForeignKey(x => x.IdUsuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Pagamento).WithMany(x => x.Agendamento)
                .HasForeignKey(x => x.IdPagamento).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
