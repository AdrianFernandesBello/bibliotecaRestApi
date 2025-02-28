using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string email, DateTime dataNascimento, int cpf) : base()
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }

        public string Nome { get;  set; }
        public string Email { get;  set; }
        public DateTime DataNascimento { get; set; }
        public int CPF { get; set; }
        public ICollection<Emprestimo> Emprestimos { get;  set; }

        public void Update(string nome, string email, DateTime dataNascimento, int cpf)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }
    }
}
