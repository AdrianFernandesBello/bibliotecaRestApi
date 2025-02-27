using DesafioBiblioteca.Core.Entities;
using DesafioBiblioteca.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<int> Add(Usuario livro)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Usuario livro)
        {
            throw new NotImplementedException();
        }
    }
}
