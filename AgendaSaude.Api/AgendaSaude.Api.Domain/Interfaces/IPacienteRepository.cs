using AgendaSaude.Api.Domain.Entities;

namespace AgendaSaude.Api.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> AdicionarPaciente(Paciente paciente);
        Task<Paciente> BuscarPacientePorId(Guid id);
        Task<List<Paciente>> ListarTodosPacientes();
        Task<List<Paciente>> listarTodosPacientesPorIdProficional(Guid id);
        Task<Paciente> EditarPaciente(Paciente paciente);
        Task<bool> DeletarPaciente(Paciente paciente);
    }
}
