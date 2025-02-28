using DesafioBiblioteca.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommand : IRequest<ResultViewModel>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CPF { get; set; }
        public int IdUsuario { get; set; }
    }
}
