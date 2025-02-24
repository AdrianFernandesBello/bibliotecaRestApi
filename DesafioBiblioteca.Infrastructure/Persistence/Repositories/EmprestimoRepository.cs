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
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaDbContext _context;
        public EmprestimoRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Emprestimo emprestimo)
        {
            await _context.Emprestimo.AddAsync(emprestimo);
            await _context.SaveChangesAsync();

            return emprestimo.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Emprestimo.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Emprestimo>> GetAll()
        {
            var emprestimos = await _context.Emprestimo
                .Include(x => x.IdUsuario)
                .Include(x => x.IdLivro)
                .Include(x => x.DataEmprestimo)
                .Include(x => x.DataDevolução)
                .ToListAsync();

            return emprestimos;
        }

        public async Task<Emprestimo> GetById(int id)
        {
            var emprestimoid = await _context.Emprestimo
                .Include (x => x.IdUsuario)
                .Include (x => x.IdLivro)
                .Include(x => x.DataEmprestimo)
                .Include(x => x.DataDevolução)
                .SingleOrDefaultAsync(x => x.Id == id);

            return emprestimoid;

        }

        public async Task Update(Emprestimo emprestimo)
        {
            _context.Emprestimo.Update(emprestimo);
            await _context.SaveChangesAsync();
        }
    }
}
