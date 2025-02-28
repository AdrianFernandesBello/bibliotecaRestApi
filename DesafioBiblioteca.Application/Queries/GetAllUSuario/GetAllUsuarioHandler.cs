using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Queries.GetAllUSuario
{
    public class GetAllUsuarioHandler : IRequestHandler<GetAllUSuarioQuery, ResultViewModel>
    {

        private readonly BibliotecaDbContext _context;
        private readonly IUsuarioRepository _repository;
        public GetAllUsuarioHandler(BibliotecaDbContext context, IUsuarioRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(GetAllUSuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repository.GetAll();

            var model = usuarios.Select(UsuarioItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<UsuarioItemViewModel>>.Sucess(model);

        }
    }
}
