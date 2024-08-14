using AgendaSaude.Api.Domain.Entities;

namespace AgendaSaude.Api.Domain.Interfaces
{
    public interface IAgendaRepository
    {
        Task<Agenda> AdicionarAgenda(Agenda agenda);
        Task<List<Agenda>> ListarAgendas();
        Task<List<Agenda>> ListarAgendasPorIdProficional(Guid id);
        Task<List<Agenda>> ListarAgendasPorIdPaciente(Guid id);
    }
}
