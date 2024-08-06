using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;
using AgendaSaude.Api.Infra.Data.Context;

namespace AgendaSaude.Api.Infra.Data.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        public readonly ApplicationDbContext _context;

        public AgendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Agenda> AdicionarAgenda(Agenda agenda)
        {
            _context.Agenda.Add(agenda);
            await _context.SaveChangesAsync();

            return agenda;
        }
    }
}
