using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.InsertEmprestimo
{
    public class InsertEmprestimoHandler : IRequestHandler<InsertEmprestimoCommand, ResultViewModel<int>>
    {
        private readonly BibliotecaDbContext _context;
        private readonly IEmprestimoRepository _repository;
        public InsertEmprestimoHandler(BibliotecaDbContext context, IEmprestimoRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = request.ToEntity();

            await _repository.Add(emprestimo);

            return ResultViewModel<int>.Sucess(emprestimo.Id);
        }
    }
}
