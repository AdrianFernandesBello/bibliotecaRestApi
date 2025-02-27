using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.DeleteEmprestimo
{
    public class DeleteEmpretimoHandler : IRequestHandler<DeleteEmprestimoCommand, ResultViewModel>
    {
        private readonly BibliotecaDbContext _context;
        private readonly IEmprestimoRepository _repository;
        public DeleteEmpretimoHandler(BibliotecaDbContext context, IEmprestimoRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);

            if (result == null)
            {
                ResultViewModel.Error("Id nao existe");
            }

            result.SetAsDeleted();
            await _context.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
