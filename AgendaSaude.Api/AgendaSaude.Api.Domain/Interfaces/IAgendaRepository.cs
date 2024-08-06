using AgendaSaude.Api.Domain.Entities;

namespace AgendaSaude.Api.Domain.Interfaces
{
    public interface IAgendaRepository
    {
        Task<Agenda> AdicionarAgenda(Agenda agenda);
    }
}
