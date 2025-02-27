using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Entities;
using DesafioBiblioteca.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.PostMarkEmprestimo
{
    public class CreateStatusInputCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public EmprestimoEnum Status { get; set; }

        public CreateStatusInputCommand(int id, EmprestimoEnum status)
        {
            Id = id;
            Status = status;
        }
    }
}
