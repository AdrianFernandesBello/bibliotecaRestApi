using DesafioBiblioteca.Core.Entities;
using DesafioBiblioteca.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecaDbContext _context;
        public UsuarioRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Usuario usuario)
        {
             _context.Usuario.Add(usuario);

            await _context.SaveChangesAsync();


            return usuario.Id;
        }

        public async Task<List<Usuario>> GetAll()
        {
            var usuarios = await _context.Usuario
                .Include(x => x.Nome)
                .Include(x => x.Email)
                .ToListAsync();


            return usuarios;
        }

        public async Task<Usuario> GetById(int id)
        {
            var usuarioid = await _context.Usuario
                .Include(x => x.Nome)
                .Include(x => x.Email)
                .Include(x => x.DataNascimento)
                .Include(x => x.CPF)
                .SingleOrDefaultAsync( x => x.Id == id);

            return usuarioid;
        }

        public async Task Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();

        }
    }
}
