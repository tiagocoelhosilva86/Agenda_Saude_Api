using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;
using AgendaSaude.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendaSaude.Api.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> GetUsuarioPorId(Guid id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.IdUsuario.Equals(id));
        }

        public async Task<List<Usuario>> ListaTodosUsuariosCadastrados()
        {
            return await _context.Usuario.ToListAsync();
        }
    }
}