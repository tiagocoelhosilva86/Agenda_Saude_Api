﻿using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;

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
                throw new KeyNotFoundException("Erro ao criar Paciente");
            }

            var pacienteViewModel = new PacienteViewModel();
            pacienteViewModel.IdPaciente = pacienteCriado.IdPaciente;
            pacienteViewModel.IdProficional = pacienteCriado.IdProficional;
            pacienteViewModel.Nome = pacienteCriado.Nome;
            pacienteViewModel.Email = pacienteCriado.Email;
            pacienteViewModel.Telefone = pacienteCriado.Telefone;

            return pacienteViewModel;


        }

        public async Task<PacienteViewModel> BuscarPacientePorId(Guid id)
        {
            var paciente = await _pacienteRepository.BuscarPacientePorId(id);

            if (paciente == null) 
            {
                throw new KeyNotFoundException("Paciente Não Encontrado");
            }

            var pacienteConvertido = new PacienteViewModel();
            pacienteConvertido.IdPaciente = paciente.IdPaciente;
            pacienteConvertido.IdProficional = paciente.IdProficional;
            pacienteConvertido.Nome = paciente.Nome;
            pacienteConvertido.Email = paciente.Email;
            pacienteConvertido.Telefone = paciente.Telefone;

            return pacienteConvertido;
        }

        public async Task<List<PacienteViewModel>> ListarTodosPacientes()
        {
            var listaPacientes = await _pacienteRepository.ListarTodosPacientes();

            return listaPacientes.Select(item => new PacienteViewModel()
            {
                IdPaciente = item.IdPaciente,
                IdProficional= item.IdProficional,
                Nome = item.Nome,
                Email = item.Email,
                Telefone = item.Telefone
            }).ToList();
        }

        public async Task<List<PacienteViewModel>> listarTodosPacientesPorIdProficional(Guid id)
        {
            var ListaPacientes = await _pacienteRepository.listarTodosPacientesPorIdProficional(id);

            return ListaPacientes.Select(item => new PacienteViewModel()
            {
                IdPaciente = item.IdPaciente,
                IdProficional = item.IdProficional,
                Nome = item.Nome,
                Email = item.Email,
                Telefone = item.Telefone
            }).ToList();
        }

        public async Task<PacienteViewModel> EditarPaciente(EditarPacienteViewMode editarPacienteViewMode, Guid id)
        {
            var pacienteEditar = await _pacienteRepository.BuscarPacientePorId(id);

            if (pacienteEditar == null)
            {
                throw new KeyNotFoundException("Paciente Não Encontrado");
            }

            pacienteEditar.Nome = editarPacienteViewMode.Nome;
            pacienteEditar.Email = editarPacienteViewMode.Email;
            pacienteEditar.Telefone = editarPacienteViewMode.Telefone;

            await _pacienteRepository.EditarPaciente(pacienteEditar);

            var pacienteEditado = new PacienteViewModel();

            pacienteEditado.IdPaciente = pacienteEditar.IdPaciente;
            pacienteEditado.IdProficional = pacienteEditar.IdProficional;
            pacienteEditado.Nome = pacienteEditar.Nome;
            pacienteEditado.Email = pacienteEditar.Email;
            pacienteEditado.Telefone = pacienteEditar.Telefone.ToString();



            return pacienteEditado;
        }

        public async Task<bool> DeletarPaciente(Guid id)
        {
           var pacienteDeletar = await _pacienteRepository.BuscarPacientePorId(id);

            if(pacienteDeletar == null)
            {
                throw new KeyNotFoundException("Paciente Não Encontrado");
            }

            await _pacienteRepository.DeletarPaciente(pacienteDeletar);

            return (true);
        }
    }
}
