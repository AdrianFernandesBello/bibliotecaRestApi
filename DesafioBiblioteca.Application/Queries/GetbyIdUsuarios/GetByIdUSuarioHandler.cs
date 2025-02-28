using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Queries.GetbyIdUsuarios
{
    public class GetByIdUSuarioHandler : IRequestHandler<GetByIdUsuarioQuery, ResultViewModel>
    {
        private readonly BibliotecaDbContext _context;
        private readonly IUsuarioRepository _repository;
        public GetByIdUSuarioHandler(BibliotecaDbContext context, IUsuarioRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarioid = await _repository.GetById(request.Id);

            if (usuarioid == null)
            {
                return ResultViewModel.Error("Id nao existente");
            }

            return ResultViewModel.Sucess();
        }
    }
}
