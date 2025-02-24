using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.InsertEmprestimo
{
    public class InsertEmprestimoCommand : IRequest<ResultViewModel<int>>
    {
        public decimal Valor { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolução { get; set; }

        public Emprestimo ToEntity() => new Emprestimo (IdUsuario, IdLivro, Valor);
    }
}
