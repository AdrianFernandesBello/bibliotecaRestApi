using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Entities;
using DesafioBiblioteca.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.UpdateLivroCommand
{
    public class UpdateLivroCommand : IRequest<ResultViewModel>
    {
        public int IdLivro { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime DataPublicação { get; set; }

    }

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
