using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Repositories;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.UpdateLivroCommand
{
    public class UpdateLivroHandler : IRequestHandler<UpdateLivroCommand, ResultViewModel>
    {
        private readonly ILivroRepository _repository;
        public UpdateLivroHandler(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            //aplicar padrao repository
            var livroid = await _repository.GetById(request.IdLivro);

            if (livroid == null)
            {
                return ResultViewModel.Error("id nao existe");
            }

            livroid.Update(request.Autor, request.Titulo, request.ISBN);

            await _repository.Update(livroid);


            return ResultViewModel.Sucess();
        }
    }
}
