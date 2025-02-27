using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.DeleteLivro
{
    public class DeleteLivroHandler : IRequestHandler<DeleteLivroCommand, ResultViewModel>
    {
        private readonly BibliotecaDbContext _context;
        private readonly ILivroRepository _repository;
        public DeleteLivroHandler(BibliotecaDbContext context, ILivroRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
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
