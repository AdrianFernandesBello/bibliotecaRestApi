using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.InsertLivro
{
    public class InsertLivroCommand : IRequest<ResultViewModel<int>>
    {
        public InsertLivroCommand(string autor, string titulo, string iSBN, DateTime dataPublicação)
        {
            Autor = autor;
            Titulo = titulo;
            ISBN = iSBN;
            DataPublicação = dataPublicação;
        }

        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime DataPublicação { get; set; }

        public Livro ToEntity() => new (Autor, Titulo, ISBN, DataPublicação);
    }
}
