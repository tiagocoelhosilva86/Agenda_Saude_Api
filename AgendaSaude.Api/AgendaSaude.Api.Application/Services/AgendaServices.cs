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

        public async Task<CreateAgendaViewModel> AdicionarAgenda(CreateAgendaViewModel creatAgendaViewModel)
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

            var agendaViewModel = new CreateAgendaViewModel();

            agendaViewModel.IdAgenda = agendaCriada.IdAgenda;
            agendaViewModel.IdProficional = agendaCriada.IdProficional;
            agendaViewModel.IdPaciente = agendaCriada.IdPaciente;
            agendaCriada.DataInicio = agendaCriada.DataInicio;
            agendaCriada.DataFim = agendaCriada.DataFim;

            return agendaViewModel;

           
        }

        public async Task<List<AgendaViewModel>> ListarAgenda()
        {
            var listaAgenda = await _agendaRepository.ListarAgendas();

            return listaAgenda.Select(item => new AgendaViewModel()
            {
                IdAgenda = item.IdAgenda,
                IdPaciente = item.IdPaciente,
                IdProficional = item.IdProficional,
                DataInicio = item.DataInicio,
                DataFim = item.DataFim,
                Paciente = new PacienteViewModel()
                {
                    IdPaciente = item.Paciente.IdPaciente,
                    IdProficional = item.Paciente.IdProficional,
                    Nome = item.Paciente.Nome,
                    Email = item.Paciente.Email,
                    Telefone = item.Paciente.Telefone,
                }
                }).ToList();
        }

        public async Task<List<AgendaViewModel>> ListarAgendasporIdProficional(Guid id)
        {
           var listaagendaproficional = await _agendaRepository.ListarAgendasporIdProficional(id);
            

            return listaagendaproficional.Select(item => new AgendaViewModel()
            {
                IdAgenda = item.IdAgenda,
                IdPaciente = item.IdPaciente,
                IdProficional = item.IdProficional,
                DataInicio = item.DataInicio,
                DataFim = item.DataFim,
                Paciente = new PacienteViewModel() { 
                IdPaciente = item.Paciente.IdPaciente,
                IdProficional = item.Paciente.IdProficional,
                Nome = item.Paciente.Nome,
                Email = item.Paciente.Email,
                Telefone = item.Paciente.Telefone,
                }
            }).ToList();
        }
    }
}
