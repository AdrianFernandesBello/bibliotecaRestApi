using DesafioBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Core.Repositories
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAll();
        Task<Livro> GetById(int id);
        Task<int> Add(Livro livro);
        Task Update(Livro livro);

    }
}
