using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Queries.GetByIdEmprestimos
{
    public class GetByIdEmprestimosQuery : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public GetByIdEmprestimosQuery(int id)
        {
            Id = id;
        }
    }


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
