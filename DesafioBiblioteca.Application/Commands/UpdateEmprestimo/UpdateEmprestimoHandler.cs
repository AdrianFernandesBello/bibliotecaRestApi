using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;


namespace DesafioBiblioteca.Application.Commands.UpdateEmprestimo
{
    public class UpdateEmprestimoHandler : IRequestHandler<UpdateEmprestimoCommand, ResultViewModel>
    {
        private readonly BibliotecaDbContext _context;
        private readonly IEmprestimoRepository _repository;
        public UpdateEmprestimoHandler(BibliotecaDbContext context,IEmprestimoRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateEmprestimoCommand request, CancellationToken cancellationToken)
        {
            //aplicar padrao repository
            var emprestimoid = await _repository.GetById(request.IdEmprestimo);

            if (emprestimoid == null)
            {
                return ResultViewModel.Error("id nao existe");
            }

            emprestimoid.Update(request.Valor);

            await _repository.Update(emprestimoid);
            

            return ResultViewModel.Sucess();
        }
    }
}
