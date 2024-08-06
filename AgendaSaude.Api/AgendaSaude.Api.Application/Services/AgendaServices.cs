using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;

namespace AgendaSaude.Api.Application.Services
{
    public class AgendaServices : IAgendaServices
    {
        public readonly IAgendaRepository _agendaRepository;

        public AgendaServices(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<AgendaViewModel> AdicionarAgenda(CreateAgendaViewModel creatAgendaViewModel)
        {
            var agenda = new Agenda();

            agenda.IdProficional = creatAgendaViewModel.IdProficional;
            agenda.IdPaciente = creatAgendaViewModel.IdPaciente;
            agenda.DataInicio = creatAgendaViewModel.DataInicio;
            agenda.DataFim = creatAgendaViewModel.DataFim;

            var agendaCriada = await _agendaRepository.AdicionarAgenda(agenda);

            if (agendaCriada == null )
            {
                throw new KeyNotFoundException("Erro ao criar Agenda");
            }

            var agendaViewModel = new AgendaViewModel();

            agendaViewModel.IdAgenda = agendaCriada.IdAgenda;
            agendaViewModel.IdProficional = agendaCriada.IdProficional;
            agendaViewModel.IdPaciente = agendaCriada.IdPaciente;
            agendaCriada.DataInicio = agendaCriada.DataInicio;
            agendaCriada.DataFim = agendaCriada.DataFim;

            return agendaViewModel;

           
        }
    }
}
