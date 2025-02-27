using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.InsertLivro
{
    public class InsertLivroHandler : IRequestHandler<InsertLivroCommand, ResultViewModel<int>>
    {
        private readonly BibliotecaDbContext _context;
        private readonly ILivroRepository _repository;
        public InsertLivroHandler(BibliotecaDbContext context, ILivroRepository repository)
        {
            _repository = repository;
            _context = context;
        }


        public async Task<ResultViewModel<int>> Handle(InsertLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = request.ToEntity();

            await _repository.Add(livro);

            return ResultViewModel<int>.Sucess(livro.Id);
        }
    }
}
