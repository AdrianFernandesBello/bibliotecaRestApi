using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string email) : base()
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get;  set; }
        public string Email { get;  set; }
        public ICollection<Emprestimo> Emprestimos { get;  set; }
    }
}
