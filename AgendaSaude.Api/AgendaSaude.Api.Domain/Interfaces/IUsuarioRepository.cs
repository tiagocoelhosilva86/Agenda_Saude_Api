using AgendaSaude.Api.Domain.Entities;

namespace AgendaSaude.Api.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<List<Usuario>> ListaTodosUsuariosCadastrados();
        Task<Usuario> BuscarUsuarioPorId(Guid id);
        Task<Usuario> AtualizarUsuario(Usuario usuario);
        Task<bool> DeletarUsuario(Usuario usuario);
    }
}
