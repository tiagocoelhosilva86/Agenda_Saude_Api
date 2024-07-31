using AgendaSaude.Api.Application.ViewModel;

namespace AgendaSaude.Api.Application.Interfaces
{
    public interface IPacienteServices
    {
        Task<PacienteViewModel> AdicionarPaciente(CreatePacienteViewMode pacienteViewModel);
    }
}