using AgendaSaude.Api.Application.ViewModel;

namespace AgendaSaude.Api.Application.Interfaces
{
    public interface IAgendaServices
    {
        Task<AgendaViewModel> AdicionarAgenda(CreateAgendaViewModel agendaViewModel);
    }
}
