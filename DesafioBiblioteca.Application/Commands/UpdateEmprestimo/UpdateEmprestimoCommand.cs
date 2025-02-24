using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Entities;
using MediatR;

namespace DesafioBiblioteca.Application.Commands.UpdateEmprestimo
{
    public class UpdateEmprestimoCommand : IRequest<ResultViewModel>
    {
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolução { get; }
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
        public decimal Valor {  get; set; }
        public int IdEmprestimo { get; set; }

    }
}
