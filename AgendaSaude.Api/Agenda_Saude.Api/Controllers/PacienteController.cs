using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Saude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        public readonly IPacienteServices _pacienteServices;

        public PacienteController(IPacienteServices pacienteServices)
        {
            _pacienteServices = pacienteServices;
        }

        [HttpPost("CadastrarPaciente/")]
        public async Task<ActionResult<PacienteViewModel>> CadastrarPaciente(CreatePacienteViewMode pacienteViewModel)
        {
            PacienteViewModel pacienteCadastrado = await _pacienteServices.AdicionarPaciente(pacienteViewModel);

            return Ok(pacienteCadastrado);
        }

        [HttpGet("BuscarPacientePorId/")]
        public async Task<ActionResult<PacienteViewModel>> BuscarPacientePorid(Guid id)
        {
            PacienteViewModel paciente = await _pacienteServices.BuscarPacientePorId(id);

            return Ok(paciente);
        }

        [HttpGet("ListarTodosPacientes/")]
        public async Task<ActionResult<List<PacienteViewModel>>> ListarPacientes()
        {
            List<PacienteViewModel> pacientes = await _pacienteServices.ListarTodosPacientes();

            return Ok(pacientes);
        }

        [HttpGet("ListarTodosPacientesPorIdProficional/")]
        public async Task<ActionResult<List<PacienteViewModel>>> ListarTodosPacientesPorIdProficional(Guid id)
        {
            List<PacienteViewModel> Pacientes = await _pacienteServices.listarTodosPacientesPorIdProficional(id);

            return Ok(Pacientes);
        }

        [HttpPost("EditarPaciente/")]
        public async Task<ActionResult<PacienteViewModel>> EditarPaciente(EditarPacienteViewMode editarPacienteViewMode, Guid id)
        {
            PacienteViewModel pacienteEditar = await _pacienteServices.EditarPaciente(editarPacienteViewMode,id);

            return Ok(pacienteEditar);
        }

        [HttpDelete("DeletarPaciente/")]
        public async Task<ActionResult<PacienteViewModel>> DeletarPaciente(Guid id)
        {
            await _pacienteServices.DeletarPaciente(id);

            return Ok(true);
        }
    }
}
