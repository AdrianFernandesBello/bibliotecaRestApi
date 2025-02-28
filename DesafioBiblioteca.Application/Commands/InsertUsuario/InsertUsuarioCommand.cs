using DesafioBiblioteca.Application.Models;
using DesafioBiblioteca.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Commands.InsertUsuario
{
    public class InsertUsuarioCommand : IRequest<ResultViewModel<int>>
    {
        public InsertUsuarioCommand(string nome, string email, DateTime dataNascimento, int cpf)
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

        public Usuario ToEntity() => new (Nome, Email, DataNascimento, CPF);
    }
}
