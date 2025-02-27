using Azure.Core;
using DesafioBiblioteca.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.DeleteEmprestimo
{
    public class DeleteEmprestimoCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteEmprestimoCommand(int id)
        {
            Id = id;
        }
    }
}
