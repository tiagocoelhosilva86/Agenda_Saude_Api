using AgendaSaude.Api.Application.ViewModel;

namespace AgendaSaude.Api.Application.Interfaces
{
    public interface IPacienteServices
    {
        Task<PacienteViewModel> AdicionarPaciente(CreatePacienteViewMode pacienteViewModel);

        Task<PacienteViewModel> BuscarPacientePorId(Guid id);

        Task <List<PacienteViewModel>> ListarTodosPacientes();

        Task <List<PacienteViewModel>> listarTodosPacientesPorIdProficional(Guid id);
    }
}