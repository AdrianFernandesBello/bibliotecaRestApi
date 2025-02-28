using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.InsertUsuario
{
    public class InsertUsuarioHandler : IRequestHandler<InsertUsuarioCommand, ResultViewModel<int>>
    {
        private readonly BibliotecaDbContext _context;
        private readonly IUsuarioRepository _repository;
        public InsertUsuarioHandler(BibliotecaDbContext context, IUsuarioRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = request.ToEntity();

            await _repository.Add(usuario);

            return ResultViewModel<int>.Sucess(usuario.Id);
        }
    }
}
