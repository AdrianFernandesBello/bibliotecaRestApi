using DesafioBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Models
{
    public class UsuarioItemViewModel
    {
        public UsuarioItemViewModel(string nome, string email, DateTime dataNascimento, int cpf)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CPF { get; set; }


        public static UsuarioItemViewModel FromEntity(Usuario usuario) => new UsuarioItemViewModel( usuario.Nome, usuario.Email, usuario.DataNascimento, usuario.CPF);
    }
}
