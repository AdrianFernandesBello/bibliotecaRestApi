using DesafioBiblioteca.Core.Entities;
using DesafioBiblioteca.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Infrastructure.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        public Task<int> Add(Livro livro)
        {
            throw new NotImplementedException();
        }

        public Task<List<Livro>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Livro> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Livro livro)
        {
            throw new NotImplementedException();
        }
    }
}
