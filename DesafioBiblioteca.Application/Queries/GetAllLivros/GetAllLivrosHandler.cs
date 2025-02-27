using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Queries.GetAllLivros
{
    public class GetAllLivrosHandler : IRequestHandler<GetAllLivrosQuery, ResultViewModel>
    {
        private readonly BibliotecaDbContext _context;
        private readonly ILivroRepository _repository;
        public GetAllLivrosHandler(BibliotecaDbContext context, ILivroRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _repository.GetAll();

            var model = livros.Select(LivrosItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<LivrosItemViewModel>>.Sucess(model);
        }
    }
}
