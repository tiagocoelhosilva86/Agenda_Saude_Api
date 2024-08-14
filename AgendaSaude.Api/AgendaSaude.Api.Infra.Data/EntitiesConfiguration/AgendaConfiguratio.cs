using AgendaSaude.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaSaude.Api.Infra.Data.EntitiesConfiguration
{
    public class AgendaConfiguratio : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(x => x.IdAgenda);
            builder.Property(x => x.IdPaciente).IsRequired();
            builder.Property(x => x.IdProficional).IsRequired();
            builder.Property(x => x.DataInicio).IsRequired();
            builder.Property(x => x.DataFim).IsRequired();

            builder.HasOne(x => x.Paciente)
                .WithMany(x => x.Agendas)
                .HasForeignKey(x => x.IdPaciente).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Proficional)
                .WithMany(x => x.Agendas)
                .HasForeignKey(x => x.IdProficional).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
