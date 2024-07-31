using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Application.Services
{
    public class PacienteServeces : IPacienteServices
    {
        public readonly IPacienteRepository _pacienteRepository;

        public PacienteServeces(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<PacienteViewModel> AdicionarPaciente(CreatePacienteViewMode createPacienteViewModel)
        {
           var paciente = new Paciente();

            paciente.IdProficional = createPacienteViewModel.IdProficional;
            paciente.Nome = createPacienteViewModel.Nome;
            paciente.Email = createPacienteViewModel.Email;
            paciente.Telefone = createPacienteViewModel.Telefone;

            var pacienteCriado = await _pacienteRepository.AdicionarPaciente(paciente);

            if (pacienteCriado == null)
            {
                throw new Exception("Erro ao criar Paciente");
            }

            var pacienteViewModel = new PacienteViewModel();
            pacienteViewModel.IdPaciente = pacienteCriado.IdPaciente;
            pacienteViewModel.IdProficional = pacienteCriado.IdProficional;
            pacienteViewModel.Nome = pacienteCriado.Nome;
            pacienteViewModel.Email = pacienteCriado.Email;
            pacienteViewModel.Telefone = pacienteCriado.Telefone;

            return pacienteViewModel;


        }
    }
}
