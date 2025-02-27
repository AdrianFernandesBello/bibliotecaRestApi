using DesafioBiblioteca.Application.Models;
using MediatR;


namespace DesafioBiblioteca.Application.Commands.DeleteLivro
{
    public class DeleteLivroCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteLivroCommand(int id)
        {
            Id = id;
        }
    }
}
