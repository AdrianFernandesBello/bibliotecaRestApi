using Azure.Core;
using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.DeleteEmprestimo
{
    public class DeleteEmprestimoCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteEmprestimoCommand(int id)
        {
            Id = id;
        }
    }


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
