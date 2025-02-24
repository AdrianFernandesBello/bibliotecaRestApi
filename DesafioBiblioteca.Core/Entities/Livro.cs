using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Core.Entities
{
    public class Livro : BaseEntity
    {
        public Livro(string autor, string titulo, string iSBN, DateTime dataPublicação) : base()
        {
            Autor = autor;
            Titulo = titulo;
            ISBN = iSBN;
            DataPublicação = dataPublicação;
        }

        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime DataPublicação { get;  set; }
        public ICollection<Emprestimo> Emprestimos { get;  set; }
    }
}
