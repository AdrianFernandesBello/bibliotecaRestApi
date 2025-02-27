using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Enums;
using DesafioBiblioteca.Core.Repositories;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.PostMarkEmprestimo
{
    public class CreateStatusInputHandler : IRequestHandler<CreateStatusInputCommand, ResultViewModel>
    {

        private readonly BibliotecaDbContext _context;
        private readonly IEmprestimoRepository _repository;
        public CreateStatusInputHandler(BibliotecaDbContext context, IEmprestimoRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(CreateStatusInputCommand request, CancellationToken cancellationToken)
        {
            var empretimoid = await _repository.GetById(request.Id);
            if (empretimoid == null)
            {
                return ResultViewModel.Error("Id nao existente");
            }

            //verifica se emprestimo esta atrasado
            if (empretimoid.DataDevolução < DateTime.UtcNow && empretimoid.Status != EmprestimoEnum.Concluido)
            {
                empretimoid.Status = EmprestimoEnum.Atrasado;
            }

            else
            {
                empretimoid.Status = EmprestimoEnum.EmAndamento;
            }

            return ResultViewModel.Sucess();
        }
    }
}
