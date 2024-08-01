using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgendaSaude.Api.Application.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioViewModel> AdicionarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuario = new Usuario();
            usuario.Nome = usuarioViewModel.Nome;
            usuario.Email = usuarioViewModel.Email;
            usuario.Senha = usuarioViewModel.Senha;

            var usuarioCriado = await _usuarioRepository.AdicionarUsuario(usuario);

            if (usuarioCriado == null)
            {
                throw new Exception("Error ao criar Usuario");
            }

            var createusuarioViewModel = new UsuarioViewModel();
            createusuarioViewModel.IdUsuario = usuarioCriado.Id;
            createusuarioViewModel.Nome = usuarioCriado.Nome;
            createusuarioViewModel.Email = usuarioCriado.Email;
            createusuarioViewModel.Senha = usuarioCriado.Senha.ToString();;

            return createusuarioViewModel;
        }

        public async Task<List<UsuarioViewModel>> listarTodosUsuariosCadastrados()
        {
            var usuarios = await _usuarioRepository.ListaTodosUsuariosCadastrados();

            return usuarios.Select(item =>  new UsuarioViewModel() 
            { IdUsuario = item.Id,
            Nome = item.Nome,
            Email = item.Email,
            Senha = item.Senha,
            }).ToList();
        }

        public async Task<UsuarioViewModel> AtualizarUsuarioCadastrado(CreateUsuarioViewModel createUsuarioViewModel, Guid id)
        {
            Usuario usuarioAtualizar = await _usuarioRepository.BuscarUsuarioPorId(id);


            if (usuarioAtualizar == null)
            {
                throw new KeyNotFoundException("Usuário não existe");
            }

            usuarioAtualizar.Nome = createUsuarioViewModel.Nome;
            usuarioAtualizar.Email = createUsuarioViewModel.Email;
            usuarioAtualizar.Senha = createUsuarioViewModel.Senha;

            await _usuarioRepository.AtualizarUsuario(usuarioAtualizar);

            var usuarioAtualizado = new UsuarioViewModel();

            usuarioAtualizado.IdUsuario = usuarioAtualizar.Id;
            usuarioAtualizado.Nome = createUsuarioViewModel.Nome;
            usuarioAtualizado.Email = createUsuarioViewModel.Email;
            usuarioAtualizado.Senha= createUsuarioViewModel.Senha;


            return usuarioAtualizado;
        }

        public async Task<UsuarioViewModel> GetUsuarioPorId(Guid idUsuario)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorId(idUsuario);

            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            var usuarioConvertido = new UsuarioViewModel();

            usuarioConvertido.IdUsuario = usuario.Id;
            usuarioConvertido.Nome = usuario.Nome;
            usuarioConvertido.Email = usuario.Email;
            usuarioConvertido.Senha = usuario.Senha;


            return usuarioConvertido;
        }

        public async Task<bool> DeletarUsuario(Guid idUsuario)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorId(idUsuario);

            if(usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

             await _usuarioRepository.DeletarUsuario(usuario);

            return (true);
        }

    }
}