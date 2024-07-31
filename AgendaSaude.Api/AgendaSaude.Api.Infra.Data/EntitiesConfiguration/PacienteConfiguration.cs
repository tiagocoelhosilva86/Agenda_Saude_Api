using AgendaSaude.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaSaude.Api.Infra.Data.EntitiesConfiguration
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.IdPaciente);
            builder.Property(x => x.IdProficional).IsRequired();
            builder.Property(x => x.Nome);
            builder.Property(x => x.Email);
            builder.Property(x => x.Telefone);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Pacientes)
                .HasForeignKey(x => x.IdProficional).OnDelete(DeleteBehavior.NoAction);
        }
    }
}