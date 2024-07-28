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
            var usuario = new Usuario(usuarioViewModel.IdUsuario, usuarioViewModel.Name, usuarioViewModel.Email, usuarioViewModel.Senha, usuarioViewModel.DateRegistro, usuarioViewModel.Admin);
            usuario.IdUsuario = usuarioViewModel.IdUsuario;
            usuario.Name = usuarioViewModel.Name;
            usuario.Email = usuarioViewModel.Email;
            usuario.Senha = usuarioViewModel.Senha;
            usuario.DateRegistro = usuarioViewModel.DateRegistro;
            usuario.Admin = usuarioViewModel.Admin;

            var usuarioCriado = await _usuarioRepository.AdicionarUsuario(usuario);

            if (usuarioCriado == null)
            {
                throw new Exception("Error ao criar Usuario");
            }

            usuarioViewModel.IdUsuario = usuarioCriado.IdUsuario;

            usuarioViewModel.Name = usuarioCriado.Name;
            usuarioViewModel.Email = usuarioCriado.Email;
            usuarioViewModel.Senha = usuarioCriado.Senha.ToString();
            usuarioViewModel.DateRegistro = usuarioCriado.DateRegistro;
            usuarioViewModel.Admin = usuarioCriado.Admin;

            return usuarioViewModel;
        }

        public async Task<List<UsuarioViewModel>> listarTodosUsuariosCadastrados()
        {
            var usuarios = await _usuarioRepository.ListaTodosUsuariosCadastrados();

            return usuarios.Select(item => new UsuarioViewModel(item.IdUsuario, item.Name, item.Email, item.Senha, item.DateRegistro, item.Admin)).ToList();
        }

        public async Task<UsuarioViewModel> AtualizarUsuarioCadastrado(UsuarioViewModel usuarioViewModel, Guid id)
        {
            Usuario usuarioAtualizar = await _usuarioRepository.GetUsuarioPorId(id);


            if (usuarioAtualizar == null)
            {
                throw new KeyNotFoundException("Usuário não existe");
            }

            usuarioAtualizar.Name = usuarioViewModel.Name;
            usuarioAtualizar.Email = usuarioViewModel.Email;
            usuarioAtualizar.Senha = usuarioViewModel.Senha;
            usuarioAtualizar.Admin = usuarioViewModel.Admin;

            await _usuarioRepository.AtualizarUsuario(usuarioAtualizar);

            var usuarioAtualizado = new UsuarioViewModel(usuarioAtualizar.IdUsuario,usuarioAtualizar.Name, usuarioAtualizar.Email, usuarioAtualizar.Senha,usuarioAtualizar.DateRegistro, usuarioAtualizar.Admin);


            return usuarioAtualizado;
        }

        public async Task<UsuarioViewModel> GetUsuarioPorId(Guid idUsuario)
        {
            var usuario = await _usuarioRepository.GetUsuarioPorId(idUsuario);

            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            var usuarioConvertido = new UsuarioViewModel(usuario.IdUsuario,usuario.Name,usuario.Email,usuario.Senha, usuario.DateRegistro,usuario.Admin);


            return usuarioConvertido;
        }

        public async Task<bool> DeletarUsuario(Guid idUsuario)
        {
            var usuario = await _usuarioRepository.GetUsuarioPorId(idUsuario);

            if(usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

             await _usuarioRepository.DeletarUsuario(usuario);

            return (true);
        }
    }
}