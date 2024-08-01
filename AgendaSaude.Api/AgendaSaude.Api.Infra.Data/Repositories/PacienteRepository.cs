using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;
using AgendaSaude.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Paciente> BuscarPacientePorId(Guid id)
        {
            return await _context.Paciente.FirstOrDefaultAsync(x => x.IdPaciente.Equals(id));
        }
        public async Task<List<Paciente>> ListarTodosPacientes()
        {
            return await _context.Paciente.ToListAsync();
        }

        public async Task<List<Paciente>> listarTodosPacientesPorIdProficional(Guid id)
        {
            return await _context.Paciente.Where(x => x.IdProficional == id).ToListAsync();
        }
    }
}