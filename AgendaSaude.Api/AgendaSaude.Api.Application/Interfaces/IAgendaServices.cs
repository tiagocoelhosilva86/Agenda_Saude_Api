using AgendaSaude.Api.Application.ViewModel;

namespace AgendaSaude.Api.Application.Interfaces
{
    public interface IAgendaServices
    {
        Task<CreateAgendaViewModel> AdicionarAgenda(CreateAgendaViewModel agendaViewModel);
        Task<List<AgendaViewModel>> ListarAgenda();
        Task <List<AgendaViewModel>> ListarAgendasPorIdProficional(Guid id);
        Task<List<AgendaViewModel>> ListarAgendasPorIdPaciente(Guid id);
    }
}
