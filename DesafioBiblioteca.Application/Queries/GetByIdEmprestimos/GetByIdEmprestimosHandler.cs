using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Queries.GetByIdEmprestimos
{
    public class GetByIdEmprestimosHandler : IRequestHandler<GetByIdEmprestimosQuery, ResultViewModel>
    {
        private readonly BibliotecaDbContext _context;
        private readonly IEmprestimoRepository _repository;
        public GetByIdEmprestimosHandler(BibliotecaDbContext context, IEmprestimoRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(GetByIdEmprestimosQuery request, CancellationToken cancellationToken)
        {
            var emprestimoid = await _repository.GetById(request.Id);

            if (emprestimoid == null)
            {
                return ResultViewModel.Error("Id nao existente");
            }

            return ResultViewModel.Sucess();
        }
    }
}
