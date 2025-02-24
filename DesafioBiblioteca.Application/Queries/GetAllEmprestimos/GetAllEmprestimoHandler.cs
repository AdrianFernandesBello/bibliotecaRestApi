using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Queries.GetAllEmprestimos
{
    public class GetAllEmprestimoHandler : IRequestHandler<GetAllEmprestimoQuery, ResultViewModel>
    {
        private readonly BibliotecaDbContext _context;
        private readonly IEmprestimoRepository _repository;
        public GetAllEmprestimoHandler(BibliotecaDbContext context, IEmprestimoRepository repository)
        {
            _repository = repository;
            _context = context;
        }


        public async Task<ResultViewModel> Handle(GetAllEmprestimoQuery request, CancellationToken cancellationToken)
        {
            var emprestimos = await _repository.GetAll();

            var model = emprestimos.Select(EmprestimoItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<EmprestimoItemViewModel>>.Sucess(model);
        }
    }
}
