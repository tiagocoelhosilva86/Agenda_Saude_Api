using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;
using AgendaSaude.Api.Infra.Data.Context;

namespace AgendaSaude.Api.Infra.Data.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        public readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente> AdicionarPaciente(Paciente paciente)
        {
            _context.Add(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }
    }
}