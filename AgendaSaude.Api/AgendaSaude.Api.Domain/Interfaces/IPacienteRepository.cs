using AgendaSaude.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
