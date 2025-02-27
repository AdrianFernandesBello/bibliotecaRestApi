using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Queries.GetbyIdLivros
{
    public class GetByIdLivrosHandler : IRequestHandler<GetByIdLivrosQuery, ResultViewModel>
    {
        private readonly BibliotecaDbContext _context;
        private readonly ILivroRepository _repository;
        public GetByIdLivrosHandler(BibliotecaDbContext context, ILivroRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(GetByIdLivrosQuery request, CancellationToken cancellationToken)
        {
            var livroid = await _repository.GetById(request.Id);

            if (livroid == null)
            {
                return ResultViewModel.Error("Id nao existente");
            }

            return ResultViewModel.Sucess();
        }
    }
}
