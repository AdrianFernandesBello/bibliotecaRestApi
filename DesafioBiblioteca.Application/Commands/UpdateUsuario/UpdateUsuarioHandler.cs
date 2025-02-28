using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, ResultViewModel>
    {
        private readonly IUsuarioRepository _repository;
        public UpdateUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            //aplicar padrao repository
            var usuarioid = await _repository.GetById(request.IdUsuario);

            if (usuarioid == null)
            {
                return ResultViewModel.Error("id nao existe");
            }

            usuarioid.Update(request.Nome, request.Email, request.DataNascimento, request.CPF);

            await _repository.Update(usuarioid);


            return ResultViewModel.Sucess();
        }
    }
}
