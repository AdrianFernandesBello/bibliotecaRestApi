using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteUsuarioCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, ResultViewModel>
    {

        private readonly BibliotecaDbContext _context;
        private readonly IUsuarioRepository _repository;
        public DeleteUsuarioHandler(BibliotecaDbContext context, IUsuarioRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
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
