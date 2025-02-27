using DesafioBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Models
{
    public class LivrosItemViewModel
    {
        public LivrosItemViewModel(string autor, string titulo, string iSBN, DateTime dataPublicação)
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


        public static LivrosItemViewModel FromEntity(Livro livro) => new(livro.Autor, livro.Titulo, livro.ISBN, livro.DataPublicação);
    }
}
