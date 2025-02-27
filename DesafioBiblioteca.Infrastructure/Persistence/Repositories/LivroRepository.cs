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
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaDbContext _context;
        public LivroRepository(BibliotecaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Livro livro)
        {
            await _context.Livro.AddAsync(livro);
            await _context.SaveChangesAsync();

            return livro.Id;
        }

        public async Task<List<Livro>> GetAll()
        {
            var livros = await _context.Livro
                .Include(x => x.Titulo)
                .Include(x => x.Autor)
                .ToListAsync();

            return livros;
        }

        public async Task<Livro> GetById(int id)
        {
            var livro = await _context.Livro
                .Include(x => x.Titulo)
                .Include(x => x.Autor)
                .Include(x => x.ISBN)
                .Include(x=> x.DataPublicação)
                .SingleOrDefaultAsync( x => x.Id == id);

            return livro;
        }

        public async Task Update(Livro livro)
        {
            _context.Livro.Update(livro);
            await _context.SaveChangesAsync();
        }
    }
}
