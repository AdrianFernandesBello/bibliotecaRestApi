using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Entities;
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
}
